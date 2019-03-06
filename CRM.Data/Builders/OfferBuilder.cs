using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class OfferBuilder
    {
        public OfferBuilder(EntityTypeConfiguration<Offer> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Amount).IsRequired().HasMaxLength(100);
            entity.HasRequired(e => e.Customer).WithMany(m => m.Offers).HasForeignKey(f => f.CustomerId);
            entity.HasRequired(e => e.Employee).WithMany(m => m.Offers).HasForeignKey(f => f.EmployeeId);
            entity.HasMany(e => e.Products).WithMany(m => m.Offers);
            entity.HasMany<Product>(p => p.Products).WithMany(m => m.Offers).Map(em =>
            {
                em.MapLeftKey("ProductRefId");
                em.MapRightKey("OfferRefId");
                em.ToTable("ProductOffer");
            });
        }
    }
}
