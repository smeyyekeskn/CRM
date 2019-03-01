using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Order:BaseEntity
    {
        public Order()
        {
            new HashSet<Product>();
        }
        [Display(Name = "İstenen Tarih")]
        public DateTime RequiredDate { get; set; }

        [Display(Name = "Sevk Tarihi")]
        public DateTime ShippedDate { get; set; }

        [Display(Name = "Ürün")]
        public Guid ProductId { get; set; }

        public virtual ICollection<Product>Products { get; set; }

    }
}
