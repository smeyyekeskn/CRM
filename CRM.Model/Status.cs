using System.ComponentModel.DataAnnotations;

namespace CRM.Model
{
    public enum Status
    {
        [Display(Name ="Potansiyel Müşteri")]
        PotentialCustomer=1,
        [Display(Name = "Aday Müşteri")]
        CandidateCustomer = 2
    }

}