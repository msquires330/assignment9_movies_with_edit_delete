using assignment3_msquires.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3_msquires.Controllers
{
    public class HomeController : Controller
    {
       // IList<NewMovieResponse> movieList = new List<NewMovieResponse>();

        // this is getting set through the constructor which can be seen in the entire class 
        private MovieContext context { get; set; }
        public HomeController(MovieContext con)
        {
            context = con; 
        }

       // private readonly ILogger<HomeController> _logger;

      //  public HomeController(ILogger<HomeController> logger) { _logger = logger;  }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(NewMovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movieResponse);
                context.SaveChanges();
               // TempStorage.AddNewMovie(movieResponse);
                return View("Confirmation", movieResponse);
            }

            return View();
        }

        public IActionResult MovieList()
        {
            return View(context.Movies.Where(NewMovieResponse => NewMovieResponse.Title != "Independence Day"));
        }

        [HttpPost]
        public IActionResult Edit1(int Id)
        {
            NewMovieResponse newMovieResponse = context.Movies.Single(x => x.id == Id);
            return View("Edit", newMovieResponse);
        }

        [HttpPost]
        public IActionResult Edit2(NewMovieResponse newMovieResponse)
        {
            if (ModelState.IsValid)
            {
                var movie = context.Movies.Single(x => x.id == newMovieResponse.id);

                context.Entry(movie).Property(x => x.Category).CurrentValue = newMovieResponse.Category;
                context.Entry(movie).Property(x => x.Title).CurrentValue = newMovieResponse.Title;
                context.Entry(movie).Property(x => x.Year).CurrentValue = newMovieResponse.Year;
                context.Entry(movie).Property(x => x.Director).CurrentValue = newMovieResponse.Director;
                context.Entry(movie).Property(x => x.Rating).CurrentValue = newMovieResponse.Rating;
                context.Entry(movie).Property(x => x.Edited).CurrentValue = newMovieResponse.Edited;
                context.Entry(movie).Property(x => x.Lent).CurrentValue = newMovieResponse.Lent;
                context.Entry(movie).Property(x => x.Notes).CurrentValue = newMovieResponse.Notes;

                context.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
                return View();
        }
           

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            // THIS LINE ALSO NEEDS HELP 
            NewMovieResponse newMovieResponse = context.Movies.Single(x => x.id == Id);
            context.Remove(newMovieResponse);
            context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
