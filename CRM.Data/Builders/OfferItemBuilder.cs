using CRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Builders
{
    public class OfferItemBuilder
    {

        public OfferItemBuilder(EntityTypeConfiguration<OfferItem> entity)
        {
            entity.HasOptional(e => e.Customer).WithMany(m => m.OfferItems).HasForeignKey(f => f.CustomerId);

            entity.HasOptional(e => e.Product).WithMany(m => m.OfferItems).HasForeignKey(f => f.ProductId);

            entity.HasOptional(e => e.Offer).WithMany(m => m.OfferItems).HasForeignKey(f => f.OfferId);
        }
    }
}
