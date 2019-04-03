using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class OrderItemBuilder
    {
        public OrderItemBuilder(EntityTypeConfiguration<OrderItem> entity)
        {
            entity.HasOptional(e => e.Customer).WithMany(m => m.OrderItems).HasForeignKey(f => f.CustomerId);

            entity.HasOptional(e => e.Product).WithMany(m => m.OrderItems).HasForeignKey(f => f.ProductId);

            entity.HasOptional(e => e.Order).WithMany(m => m.OrderItems).HasForeignKey(f => f.OrderId);
        }
    }
}
