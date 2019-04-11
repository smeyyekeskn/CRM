using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UI.ViewModel
{
    public class OfferItemViewModel
    {
        public string SerialNumber { get; set; }
        public decimal OfferPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime RegisterRequiredDate { get { return DateTime.Now; } }
    }
}