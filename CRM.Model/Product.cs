using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Product:BaseEntity
    {
        public Product()
        {
            new HashSet<Order>();
            new HashSet<Offer>();
            new HashSet<Product>();
        }
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Seri Numarası")]
        public string SerialNumber { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal BuyingPrice { get; set; }

        [Display(Name="Stok")]
        public int Stock { get; set; }

        [Display(Name = "Kategori")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Sipariş")]
        public Guid OrderId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [Display(Name = "Teklif")]
        public Guid OfferId { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        [Display(Name = "Ürün")]
        public Guid ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
