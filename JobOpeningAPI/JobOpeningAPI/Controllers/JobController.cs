using JobOpeningAPI.ApiResponse;
using JobOpeningAPI.DataContext;
using JobOpeningAPI.Models;
using JobOpeningAPI.Services;
using JobOpeningAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

namespace JobOpeningAPI.Controllers
{
    [Authorize]
    public class JobController : ApiController
    {
        private readonly IJobService _jobService;
        JobsOpeningContext dbContext = new JobsOpeningContext();

        public JobController()
        {

        }
        public JobController(IJobService jobService)
        {
            this._jobService = jobService;
        }



        [Route("api/v1/jobs")]
        [HttpPost()]
        public HttpResponseMessage AddJobs(JobApiRequest jobApiRequest)
        {
            Job job = new Job
            {
                JobTitle = jobApiRequest.JobTitle,
                Description = jobApiRequest.Description,
                LocationId = jobApiRequest.LocationId,
                DepartmentId = jobApiRequest.DepartmentId,
                postedDate = DateTime.Now,
                closingDate = jobApiRequest.ClosingDate
            };
            dbContext.Set<Job>().Add(job);
            dbContext.SaveChanges();


            var result = dbContext.Jobs.OrderByDescending(x => x.postedDate).FirstOrDefault();
            var newJObId = result.JobId.ToString();
            if (result != null && !string.IsNullOrEmpty(newJObId))
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                return Request.CreateResponse(HttpStatusCode.Created, (int)HttpStatusCode.Created + " " + url + "/" + newJObId);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/v1/jobs/{id}")]
        [HttpPut()]
        public HttpResponseMessage EditJobs([FromBody] JobApiRequest jobApiRequest, int id)
        {
            var existingjob = dbContext.Jobs.Where(x => x.JobId == id).FirstOrDefault<Job>();
            if (existingjob != null)
            {
                existingjob.JobTitle = jobApiRequest.JobTitle;
                existingjob.Description = jobApiRequest.Description;
                existingjob.LocationId = jobApiRequest.LocationId;
                existingjob.DepartmentId = jobApiRequest.DepartmentId;
                existingjob.postedDate = DateTime.Now;
                existingjob.closingDate = jobApiRequest.ClosingDate;
                dbContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, (int)HttpStatusCode.OK + " " + HttpStatusCode.OK.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, (int)HttpStatusCode.NotFound + " " + HttpStatusCode.NotFound.ToString());
        }

        [Route("api/v1/jobs/{id}")]
        [HttpGet()]
        public HttpResponseMessage GetJobById(int id)
        {
            //var Job = dbContext.Jobs.Include(x => x.location).Include(x=>x.department).Where(x => x.JobId == id).FirstOrDefault<Job>();
            var Job = (from j in dbContext.Jobs
                       join dept in dbContext.Departments on j.DepartmentId equals dept.DepartmentId
                       join loca in dbContext.Locations on j.LocationId equals loca.LocationId
                       where j.JobId == id
                       select new
                       {
                           j.JobId,
                           j.Code,
                           j.JobTitle,
                           j.Description,
                           j.location,
                           j.department,
                           j.postedDate,
                           j.closingDate
                       }).ToList();
            if (Job.Count > 0)
            {

                return Request.CreateResponse(Job);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, (int)HttpStatusCode.NotFound + " " + HttpStatusCode.NotFound.ToString());
        }

        [Route("api/jobs/list")]
        [HttpGet()]
        public HttpResponseMessage GetJobs(JObList jObList)
        {
            JobApiResponse jobApiResponse = new JobApiResponse();
            var jobs = (from j in dbContext.Jobs
                        select new JobDTO
                        {
                            JobId = j.JobId,
                            Code = j.Code,
                            JobTitle = j.JobTitle,
                            Location = j.location.LocationTitle,
                            Department = j.department.DepartmentTitle,
                            LocationId = j.LocationId,
                            DepartmentId = j.DepartmentId,
                            postedDate = j.postedDate,
                            closingDate = j.closingDate
                        }).ToList();

            if (jobs.Count > 0)
            {
                if (jObList.LocationId != 0)
                {
                    jobs = jobs.Where(x => x.LocationId == jObList.LocationId).ToList();
                }
                if (jObList.DepartmentId != 0)
                {
                    jobs = jobs.Where(x => x.DepartmentId == jObList.DepartmentId).ToList();
                }
                jobApiResponse.total = jobs.Count;
                var matchingvalues = jobs.Where(x => x.JobTitle.Contains(jObList.q) || x.JobId.ToString().Contains(jObList.q) || x.Code.Contains(jObList.q) || x.Location.Contains(jObList.q) || x.Department.Contains(jObList.q));

                jobs = matchingvalues.Skip((jObList.pageNo - 1) * jObList.pageSize).Take(jObList.pageSize).ToList();

                
                jobApiResponse.data = jobs;
                return Request.CreateResponse(jobApiResponse);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, (int)HttpStatusCode.NotFound + " " + HttpStatusCode.NotFound.ToString());
        }
    }
}
