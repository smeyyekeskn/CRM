using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Region:BaseEntity
    {
        [Display(Name="Bölge Adı")]
        public string Name { get; set; }
        [Display(Name = "Müşteri")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Çalışan")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
