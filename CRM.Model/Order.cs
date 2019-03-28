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

        [Display(Name = "Seri Numarası")]
        public string SerialNumber { get; set; }


        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Display(Name = "İstenen Tarih")]
        public DateTime RequiredDate { get { return DateTime.Now; } }

        [Display(Name = "Satış Fiyatı")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Display(Name = "Tutar")]
        public decimal Total { get { return SellingPrice * Quantity;} }

        [Display(Name = "Müşteri")]
        public Guid? CustomerId { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Product>Products { get; set; }

    }
}
