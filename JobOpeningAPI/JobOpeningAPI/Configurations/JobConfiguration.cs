using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Configurations
{
    public class JobConfiguration : BasicEntityConfiguration<Job>
    {
        public JobConfiguration()
        {
            this.ToTable("JOB");

            Property(p => p.JobId).HasColumnName("JOB_ID");
            Property(p => p.Code).HasColumnName("CODE").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(p => p.JobTitle).HasColumnName("JOB_TITLE").IsRequired();
            Property(p => p.Description).HasColumnName("_DESCRIPTION").IsRequired();
            Property(p => p.LocationId).HasColumnName("LOCATION_ID").IsRequired();
            Property(p => p.DepartmentId).HasColumnName("DAPARTMENT_ID").IsRequired();
            Property(p => p.postedDate).HasColumnName("POSTED_DATE").IsRequired();
            Property(p => p.closingDate).HasColumnName("CLOSING_DATE").IsRequired();
        }
    }
}