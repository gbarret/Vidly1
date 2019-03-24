using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }  // This is a Navigation Property
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }  // Foreign Key

    }
}