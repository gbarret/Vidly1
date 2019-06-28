using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Rental
    {
        public int Id { get; set; }

        // ************************ Foreign Keys *******************

        // Foreign Key ... CustomerId ...
        [Required]
        public Customer Customer { get; set; }    // Navigation Property

        // Foreign Key ... MovieId ...
        [Required]
        public Movie Movie { get; set; }    // Navigation Property

        // ******** Dates *****
       
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}