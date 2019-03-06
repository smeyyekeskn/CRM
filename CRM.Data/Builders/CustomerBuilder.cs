using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class CustomerBuilder
    {
        public CustomerBuilder(EntityTypeConfiguration<Customer> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.IdentityNumber).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.HasOptional(e => e.Region).WithMany(m => m.Customers).HasForeignKey(f => f.RegionId);
        }
    }
}
