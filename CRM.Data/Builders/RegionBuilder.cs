using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class RegionBuilder
    { 
        public RegionBuilder(EntityTypeConfiguration<Region> entity)
        {
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);

        }
    }
}
