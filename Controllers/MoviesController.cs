﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() {Name = "Shrek"},
                new Movie() {Name = "Wall-e"}
            };
            
            return View(movies);
        }
    }
}