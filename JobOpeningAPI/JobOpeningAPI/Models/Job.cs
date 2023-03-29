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

        //[ForeignKey("Locations")]
        public int LocationId { get; set; }
        //[ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        
        public virtual Department department { get; set; }
        //[NotMapped]
        //public List<Department> Departments { get; set; }
        
        public virtual Location location { get; set; }
        //[NotMapped]
        //public List<Location> Locations { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }
}