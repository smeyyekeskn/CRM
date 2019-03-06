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
            new HashSet<Product>();
        }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }

        [Display(Name ="Teklif Fiyatı")]
        public string Amount { get; set; }

        [Display(Name = "Müşteri")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Çalışan")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee{ get; set; }

        [Display(Name = "Ürün")]
        public Guid ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
