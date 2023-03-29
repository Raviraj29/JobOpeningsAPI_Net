using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Configurations
{
    public class DepartmentConfiguration : BasicEntityConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            this.ToTable("DEPARTMENT");

            Property(p => p.DepartmentId).HasColumnName("DEPARTMENT_ID");
            Property(p => p.DepartmentTitle).HasColumnName("DEPARTMENT_TITLE").IsRequired();
        }
    }
}