using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class OfferItem : BaseEntity
    {
        [Display(Name = "Seri Numarası")]
        public string SerialNumber { get; set; }

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Display(Name = "Kayıtlı Tarih")]
        public DateTime RegisterRequiredDate { get; set; }

        [Display(Name = "Teklif Fiyatı")]
        public decimal OfferPrice { get; set; }

        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; }

        [Display(Name = "Tutar")]
        public decimal Total { get { return OfferPrice * Quantity; } }

        [Display(Name = "Müşteri")]
        public Guid? CustomerId { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Customer Customer { get; set; }

        public Guid? ProductId { get; set; }
        public Product Product { get; set; }

        public Guid? OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
