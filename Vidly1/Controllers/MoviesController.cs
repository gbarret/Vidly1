using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor ... Later will replace this with Dependency Injection ...
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // Later this will be replaced using Dependency Injection ...
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.ToList();
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(byte Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            return View(movie);
        }

        public ActionResult New()
        {
            // Initializing Genres used for the Form's DropDown ...
            var viewModel = new MovieNewViewModel
            {
                Genres = _context.Genres.ToList()
            };

            // Override the View to go to "MovieForm" instead of using the default "New"...
            // return View(viewModel);
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            // Checking if Movie exists ...
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieNewViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };

            // Override the View to go to "MovieForm" instead of using the default "Edit"...
            // return View(viewModel);
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                // Updating some properties ..
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock; 
            }

            _context.SaveChanges();

           return RedirectToAction("Index", "Movies");
        }
    }
}