using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_cl464.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_cl464.Controllers
{
    // Controller that handles the routes of the application

    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        // Constructor
        public HomeController(MovieContext movie)
        {
            movieContext = movie;
        }

        // returns the Index view
        public IActionResult Index()
        {
            return View();
        }

        // returns the Podcasts view
        public IActionResult Podcasts()
        {
            return View();
        }

        // if the request is a GET, return the SubmitMovie view
        [HttpGet]
        public IActionResult SubmitMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        // if the request is a POST and model is valid, add and save changes to database and return confirmation view
        // else return the SubmitMovie view again
        [HttpPost]
        public IActionResult SubmitMovie(MovieForm response)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(response);
                movieContext.SaveChanges();

                return View("Confirmation", response);
            }

            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View(response);
            }
            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = movieContext.responses
                .Include(x => x.Category)
             // .Where(x => x.Edited == false)
                .OrderBy(x => x.Category)
                .ToList();

            return View(movies);
        }

        // Edit(parameter name) needs to match the route name specified in the startup file and the asp-route-(param name)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            var movie = movieContext.responses.Single(x => x.MovieId == id);

            return View("SubmitMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieForm entry)
        {
            movieContext.Update(entry);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = movieContext.responses.Single(x => x.MovieId == id);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieForm movie)
        {
            movieContext.responses.Remove(movie);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
