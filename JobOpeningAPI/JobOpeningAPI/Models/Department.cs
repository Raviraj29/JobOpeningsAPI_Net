using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Models
{
    public class Department : BaseEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }

    }
}