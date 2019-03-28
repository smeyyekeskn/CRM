using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRM.Model
{
    public enum CustomerStatusType
    {
        [Display(Name ="Potansiyel Müşteri")]
        PotentialCustomer=1,
        [Display(Name = "Müşteri")]
        Customer = 2
    }
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
    public static class CustomerStatusTypeExtensions
    {
        public static string GetCustomerStatusTypeName(this CustomerStatusType cst)
        {
            var attr = cst.GetAttribute<DisplayAttribute>();
            return attr.GetName();
        }
    }

}