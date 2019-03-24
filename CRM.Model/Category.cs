using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Category:BaseEntity
    {
        public Category()
        {
            new HashSet<Product>();
        }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set;}

        public virtual ICollection<Product> Products { get; set; }
    }
}
