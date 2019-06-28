using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Vidly1.Models;
using Vidly1.Dtos;
using AutoMapper;

namespace Vidly1.Controllers.Api
{
    public class MoviesController : ApiController
    {
        // 20190410 ... Defining the context to get the data from the DB ...
        private ApplicationDbContext _context;

        // 20190410 ...  DbContext Constructor ...
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        // 20190410 ... public IEnumerable<string> Get()
        // 20190508 ..public IEnumerable<Movie> Get()
        public IHttpActionResult Get()
        {
            // 20190410 ... return new string[] { "value1", "value2" };
            // 20190508 ... return _context.Movies.ToList();
            var movieDtos = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
;        }

        // GET api/<controller>/5
        // 20190410 ... public string Get(int id)
        public IHttpActionResult Get(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return BadRequest();

            // 20190410 ... return "value";
            // 20190410 ... return Ok(movie);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/<controller>
        // 20190410 ... public void Post([FromBody]string value)
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id; // 20190411 Retrieving the Id from the Domain Model ...
            // 20190411 The Uri used to get the new created resource ...
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, MovieDto movieDto)
        {
            // Testing API with Postman use URL parameters:
            // URL Parameter Key => Content-Type, and Value => application/json
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}