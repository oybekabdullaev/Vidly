using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie() { Id = 1, Name = "Shrek" },
            new Movie() { Id = 2, Name = "Wall-e" }
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View(_movies);
        }

        // GET: Movies/Details/{id}
        public ActionResult Details(int id)
        {
            var movie = _movies.SingleOrDefault(m => m.Id == id);
            
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}