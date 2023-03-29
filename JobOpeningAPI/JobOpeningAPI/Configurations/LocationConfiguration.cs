using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Configurations
{
    public class LocationConfiguration : BasicEntityConfiguration<Location>
    {
        public LocationConfiguration()
        {
            this.ToTable("_LOCATION");

            Property(p => p.LocationId).HasColumnName("LOCATION_ID");
            Property(p => p.LocationTitle).HasColumnName("LOCATION_TITLE").IsRequired();
            Property(p => p.City).HasColumnName("CITY").IsRequired();
            Property(p => p.State).HasColumnName("_STATE").IsRequired();
            Property(p => p.Country).HasColumnName("COUNTRY").IsRequired();
            Property(p => p.Zip).HasColumnName("ZIP").IsRequired();
        }
    }
}