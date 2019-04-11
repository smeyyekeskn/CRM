using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Offer:BaseEntity
    {
        public Offer()
        {
            OfferItems = new HashSet<OfferItem>();
        }
        public virtual ICollection<OfferItem> OfferItems { get; set; }
    }
}
