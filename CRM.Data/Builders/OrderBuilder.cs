using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{ 
    public class OrderBuilder
    {
        public OrderBuilder(EntityTypeConfiguration<Order> entity)
        {
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Iban).IsRequired();
            entity.HasMany<Product>(p => p.Products).WithMany(m => m.Orders).Map(em =>
            {
                em.MapLeftKey("ProductRefId");
                em.MapRightKey("OrderRefId");
                em.ToTable("ProductOrder");
            });
        }

    }
}
