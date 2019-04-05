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
        // Data Annotation are used to override Editor Framework Conventions used in view's labels ...
        // Data Annotation are used to validate Action's Parameters ...
        //[Required]
        [Required(ErrorMessage = "Please enter customer's name.")]  // Overriden Default Error Message ...
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]   // This is Custom validation (defined in Models/Min18YearIfAMember.cs class) ...
        public DateTime? Birthdate { get; set; }
 
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }  // This is a Navigation Property

        [Display(Name = "Membership Type")]
        // This field is implicitly Required (we do not need to add Data Attribute "Required"
        // To make this property "optional" then use "?" becoming "byte?" that means "Nullable Byte" ...
        public byte MembershipTypeId { get; set; }  // Foreign Key

    }
}