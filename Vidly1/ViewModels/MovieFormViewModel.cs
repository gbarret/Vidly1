using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    // 20190401 used by Movie's properties ...
using System.Linq;
using System.Web;
using Vidly1.Models;

namespace Vidly1.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        // 20190401 Replace Movie with individual Movie's properties thta we nee to initilize in a form ...
        // 20190401 ... public Movie Movie { get; set; }

        // 20190401  Making properties Nullable in order to avoid filling a new form with default values like 0 for "int", and "1 Jan 0001" for dates ...
        public int? Id { get; set; }    // Using "?" to make this property Nullable in the form ...

        [Required]
        [StringLength(255)]
        public string Name { get; set; }    // String are Nullable by default. We do not need to add "?" ...

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }  // Using "?" to make this property Nullable in the form ...

        // DateAdded is not Required here because it is not capture in the form ...

        [Required]
        public DateTime? DateModified { get; set; }  // 201903402 Added by me ...

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }    // Using "?" to make this property Nullable in the form ...

        // Genre is not required here. Only GenreId is usded in the form ...

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }   // Using "?" to make this property Nullable in the form ...


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }

        }

        // Default Constructor use for New ...
        public MovieFormViewModel()
        {
            Id = 0; // Use in the HiddenField to know if New or Edit ...
        }

        // Constructor ... Initializing Properties. Used for Edit ...
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            DateModified = DateTime.UtcNow;   // 20190402 Added by me in order to update this date everytime it is Edit(ed)...
        }
    }
   
}