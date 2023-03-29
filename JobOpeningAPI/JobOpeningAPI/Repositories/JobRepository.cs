using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JobOpeningAPI.DataContext;
using JobOpeningAPI.Models;

namespace JobOpeningAPI.Repositories
{
    public class JobRepository 
    {
        private readonly JobsOpeningContext dataContext;

        public JobRepository(JobsOpeningContext dataContext)
            : base()
        {
            this.dataContext = dataContext;
        }

        public void AddJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            var set = this.dataContext.Set<Job>();
            set.Add(job);
            dataContext.SaveChanges();
        }

        public Job GetJobId()
        {
            return dataContext.Jobs.OrderByDescending(x => x.postedDate).FirstOrDefault();
        }
    }
}