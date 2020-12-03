using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        // GET /api/movies/{id}
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        // PUT /api/movies/{id}
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult EditMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var oldMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (oldMovie == null)
                return NotFound();

            Mapper.Map(movieDto, oldMovie);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/{id}
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult RemoveMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
