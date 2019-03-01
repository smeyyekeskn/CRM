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
        [Display(Name ="Açıklama")]
        public string Description { get; set; }

        [Display(Name ="Teklif Tutarı")]
        public string Amount { get; set; }

        [Display(Name = "Müşteri")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Ürün")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
