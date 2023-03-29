using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.ApiResponse
{
    public class BaseApiResponse
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }
    }
}