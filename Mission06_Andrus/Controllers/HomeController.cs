using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Andrus.Models;

namespace Mission06_Andrus.Controllers
{
    public class HomeController : Controller
    {
        // The database context for accessing the Movies table
        private readonly AddMovieContext _context;

        // Constructor: injects the database context into the controller
        public HomeController(AddMovieContext context)
        {
            _context = context;
        }

        // Home
        public IActionResult Index()
        {
            return View();
        }

        // Get to know page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Add movie page
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Form submission for adding a movie
        [HttpPost]
        public IActionResult AddMovie(AddMovie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie); // Add the new movie to the database context
                _context.SaveChanges(); // Save changes to the database
                ModelState.Clear(); // Clear the form after successful submission
                ViewBag.Message = "Movie added successfully!";  // Send Success message to ViewBag
                return View(new AddMovie());  // Redisplay the form after successful submission
            }

            ViewBag.Message = "";
            return View(movie);  // redisplay the form with validation errors
        }
    }
}
