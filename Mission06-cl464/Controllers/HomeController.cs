using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieContext movieContext { get; set; }

        // Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext movie)
        {
            _logger = logger;
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
                return View(response);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
