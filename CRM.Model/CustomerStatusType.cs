using System.ComponentModel.DataAnnotations;
namespace CRM.Model
{ 
    public enum CustomerStatusType
    {
        [Display(Name ="Potansiyel Müşteri")]
        PotentialCustomer=1,
        [Display(Name = "Müşteri")]
        Customer = 2,


    }
}