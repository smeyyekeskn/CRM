using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class ProductBuilder 
    {
        public ProductBuilder(EntityTypeConfiguration<Product> entity)
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.SerialNumber).IsRequired().HasMaxLength(100);
            entity.HasRequired(p => p.Category).WithMany(m => m.Products).HasForeignKey(f => f.CategoryId);
        }
    }
}
