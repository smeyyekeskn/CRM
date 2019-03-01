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
        }
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Seri Numarası")]
        public string SerialNumber { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal BuyingPrice { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SellingPrice { get; set; }
        [Display(Name = "Sipariş")]
        public Guid OrderId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
