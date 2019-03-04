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

        [Display(Name = "Banka Adı")]
        public string Name { get; set; }

        [Display(Name = "Iban")]
        public string Iban { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SellingPrice { get; set; }

        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Display(Name = "Tutar")]
        public decimal Amount { get { return SellingPrice * Quantity;} }

        [Display(Name = "Ürün")]
        public Guid ProductId { get; set; }

        public virtual ICollection<Product>Products { get; set; }

    }
}
