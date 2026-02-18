using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Andrus.Models;

namespace Mission06_Andrus.Controllers
{
    public class HomeController : Controller
    {
        // The database context for accessing the Movies table
        private readonly MovieContext _context;

        // Constructor: injects the database context into the controller
        public HomeController(MovieContext context)
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // Pass categories to the view for dropdown
            return View(new RealMovie());
        }

        // Form submission for adding a movie
        [HttpPost]
        public IActionResult AddMovie(RealMovie movie)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                ViewBag.Message = "Movie added Successfully!";

                return RedirectToAction("AddMovie"); // cleaner
            }

            return View(movie);  // This preserves validation errors
        }


        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .OrderBy(m => m.Year) // Order movies by Year
                .ToList(); // Convert to list for the view
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            var movie = _context.Movies
                .Single(x => x.MovieId == id); // Find the movie by ID

            return View("AddMovie", movie); // Pass the movie to the view for editing
        }

        [HttpPost]
        public IActionResult Edit(RealMovie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie); // Update the movie in the database context
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("MovieList"); // Redirect to the movie list after successful edit
            }
            return View("AddMovie", movie); // Redisplay the form with validation errors
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Single(x => x.MovieId == id); // Find the movie by ID
            return View(movie); // Pass the movie to the view for confirmation
        }

        [HttpPost]
        public IActionResult Delete(RealMovie movie)
        {
            _context.Movies.Remove(movie); // Remove the movie from the database context
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("MovieList"); // Redirect to the movie list after successful deletion
        }
    }
}
