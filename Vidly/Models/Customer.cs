using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name="Imię")]
        [MaxLength(15)]
        [Required(ErrorMessage = "Podaj Imię Klienta.")]
        public string Name { get; set; }

        [MaxLength(15)]
        [Display(Name="Nazwisko")]
        [Required]
        public string Surname { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Min18YearsIfAMember]
        [Display(Name="Data urodzenia")]
        public DateTime? Birthday { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Rodzaj konta")]
        public byte MembershipTypeId { get; set; }
    }
}