using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.ApiResponse
{
    public class JobApiResponse
    {
        //public BaseApiResponse Response { get; set; }

        public int total { get; set; }
        public List<JobDTO> data { get; set; }
    }

    public class JobApiRequest
    {
        public int JobId { get; set; }

        public string Code { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }

    public class JObList
    {
        public string q { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
    }
}