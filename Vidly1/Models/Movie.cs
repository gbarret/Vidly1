using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        //public DateTime? ReleaseDate { get; set; }    // The ? makes this property optional ...
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateModified { get; set; }  // 201903402 Added by me ...

        [Display(Name="Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }    // Navigation Property

        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }   // Foreign Key

        public Movie()
        {
            // 20190402 Define Default Value ... There are other e=ways to do this, But I do not now, at this time, whuich oine is the best one ..
            this.DateAdded = DateTime.UtcNow;   // Initializing for new records ...
            // DateModified has to be updated in the Edit???
            this.DateModified = DateTime.UtcNow;// Initializing for new records ...
        }
    }
}