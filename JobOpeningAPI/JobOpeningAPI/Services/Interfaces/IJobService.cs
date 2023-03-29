using JobOpeningAPI.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Services.Interfaces
{
    public interface IJobService 
    {
        string AddJob(JobApiRequest jobApiRequest);
    }
}