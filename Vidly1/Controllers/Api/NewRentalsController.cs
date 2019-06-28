using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Dtos;
using Vidly1.Models;

namespace Vidly1.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        // 20190623 ... Defining the context to get the data from the DB ...
        private ApplicationDbContext _context;

        // 20190623 ...  DbContext Constructor ...
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentasl(NewRentalDto newRental)
        {
            // 20190624 Get Customer data ...
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            // 20190624 Get Movie data ...
            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();
                
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
        }

        _context.SaveChanges();

        return Ok();
        }
    }
}
