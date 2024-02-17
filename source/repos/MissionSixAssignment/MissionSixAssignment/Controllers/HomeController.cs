using Microsoft.AspNetCore.Mvc;
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

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View("MovieList");
        }  
        
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return View("MovieList",movie);
        }
    }
}
