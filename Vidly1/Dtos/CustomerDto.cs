using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly1.Models;

namespace Vidly1.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }  // Foreign Key

        public MembershipTypeDto MembershipType  { get; set; }  // 20190501 used in Api/CustomerController ... 

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}