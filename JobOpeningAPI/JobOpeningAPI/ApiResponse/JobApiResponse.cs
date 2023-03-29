using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.ApiResponse
{
    public class JobApiResponse
    {
        public BaseApiResponse Response { get; set; }


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
}