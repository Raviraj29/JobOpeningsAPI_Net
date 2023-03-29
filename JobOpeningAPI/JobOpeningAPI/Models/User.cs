using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}