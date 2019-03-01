using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class BankAccount:BaseEntity
    {
        [Display(Name ="Banka Adı")]
        public string Name { get; set; }
        [Display(Name = "Iban")]
        public string Iban { get; set; }
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }
        
    }
}
