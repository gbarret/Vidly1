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
            var viewModel = new MovieFormViewModel
            {
                // 20190331 Initializing Movie in order to have default values like Id = 0 used in view Save() ...
                // 20190401 ... Movie = new Movie(),
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

            // 20190401 ... var viewModel = new MovieFormViewModel
            // Passing the object movie when instatiating the viewModel. Required now that properties are defined there ...
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
                // 20190401 ...Movie = movie
            };

            // Override the View to go to "MovieForm" instead of using the default "Edit"...
            // return View(viewModel);
            return View("MovieForm", viewModel);
        }

        [ValidateAntiForgeryToken]  // Preventing Cross-Site Request Forgery (Also, add hidden Field in View)...
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                // 20190401 ... var viewModel = new MovieFormViewModel
                // Passing the object movie when instatiating the viewModel. Required now that properties are defined there ...
                var viewModel = new MovieFormViewModel(movie)
                {
                    // 20190401 ... Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
                

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
                movieInDb.DateModified = movie.DateModified;    // This is updated in the MovieFormViewModel.cs ....
            }

            _context.SaveChanges();

           return RedirectToAction("Index", "Movies");
        }
    }
}