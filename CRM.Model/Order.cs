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
           OrderItems = new HashSet<OrderItem>();
        }
        
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
