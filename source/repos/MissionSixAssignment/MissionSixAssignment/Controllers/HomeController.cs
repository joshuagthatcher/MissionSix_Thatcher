using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissionSixAssignment.Models;
using System.Diagnostics;

namespace MissionSixAssignment.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie());
        }  
        
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return View("MovieList");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
                ViewBag.Title ="Error";
                return View(movie);
            }
        }

        public IActionResult MovieList()
        {
            var movie = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Include(x => x.Category)
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
