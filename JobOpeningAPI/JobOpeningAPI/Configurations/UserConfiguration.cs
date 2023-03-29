using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Configurations
{
    public class UserConfiguration : BasicEntityConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("USERS");

            Property(p => p.UserId).HasColumnName("_USER_ID");
            Property(p => p.UserName).HasColumnName("_USER_NAME").IsRequired();
            Property(p => p.Password).HasColumnName("_PASSWORD").IsRequired();
        }
    }
}