﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class Employee:BaseEntity    
    {
        public Employee()
        {
            OfferItems = new HashSet<OfferItem>();
        }
        [Display(Name ="TC Kimlik No")]
        public string IdentityNumber { get; set; }

        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; } 

        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Statü")]
        public UserType UserType{ get; set; }

        [Display(Name = "Bölge")]
        public Guid? RegionId { get; set; }
        [Display(Name = "Bölge")]
        public virtual Region Region { get; set; }

        public virtual ICollection<OfferItem> OfferItems { get; set; }


    }
}
