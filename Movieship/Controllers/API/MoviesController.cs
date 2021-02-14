using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Movieship.DTOs;
using Movieship.Models;

namespace Movieship.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // get:api/get to show only a list
        [HttpGet]
        public IEnumerable<MoviesDto> GetMovies(string query = null)
        {
            var moviequery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
               moviequery = moviequery.Where(m => m.Name.Contains(query));
            

            return (moviequery.ToList().Select(Mapper.Map<Movies, MoviesDto>));

        }
        [HttpGet]
        public IHttpActionResult GetMovies(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MoviesDto>(movie));

            
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult CreateMovie(MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDto, Movies>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult UpdateMovie(int Id, MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieindb = _context.Movies.Single(c => c.Id == Id);
            if (movieindb == null)
                return NotFound();

            Mapper.Map(movieDto, movieindb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieinDb = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movieinDb == null)
                return NotFound();
            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
