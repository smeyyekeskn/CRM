using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UI.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime RequiredDate { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
