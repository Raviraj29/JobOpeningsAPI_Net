using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Web;

namespace JobOpeningAPI.Models
{
    public class Job : BaseEntity
    {
        public int JobId { get; set; }
        public string Code { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }

        public int LocationId { get; set; }
        
        public int DepartmentId { get; set; }

        
        public virtual Department department { get; set; }
        
        public virtual Location location { get; set; }
        
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }
    public class JobDTO
    {
        public int JobId { get; set; }
        public string Code { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public int LocationId { get; set; }
        [JsonIgnore]
        public int DepartmentId { get; set; }
        public string Department { get; set; }

        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }
}