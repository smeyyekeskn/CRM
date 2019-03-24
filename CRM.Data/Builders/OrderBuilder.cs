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
            entity.HasOptional(e => e.Customer).WithMany(m => m.Orders).HasForeignKey(f => f.CustomerId);
            entity.HasMany<Product>(p => p.Products).WithMany(m => m.Orders).Map(em =>
            {
                em.MapLeftKey("ProductRefId");
                em.MapRightKey("OrderRefId");
                em.ToTable("ProductOrder");
            });
        }

    }
}
