using JobOpeningAPI.ApiResponse;
using JobOpeningAPI.Models;
using JobOpeningAPI.Repositories;
using JobOpeningAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Services
{
    public class JobService : IJobService
    {
        private readonly JobRepository jobRepository;

        public JobService()
        {
        }

        public JobService(JobRepository _jobRepository)
        {
            this.jobRepository = _jobRepository;
        }

        public string AddJob(JobApiRequest jobApiRequest)
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

            this.jobRepository.AddJob(job);
            return this.jobRepository.GetJobId().JobId.ToString();
        }
    }
}