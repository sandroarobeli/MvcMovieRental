using Microsoft.AspNetCore.Mvc;
using MvcMovieRental.Models;
using MvcMovieRental.ViewModels;

namespace MvcMovieRental.Controllers
{
     // CTRL + SHIFT + B - BUILDS AND RUNS WITHOUT STARTING A NEW WINDOW
    public class FilmsController : Controller
    {
        // GET: Films/Random
        public IActionResult Random()
        {
            var film = new Film() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomFilmViewModel { Film = film, Customers = customers };
            return View(viewModel);
            // ViewResult, ContentResult, JsonResult, RedirectResult etc are all subtypes ActionResult and thus IActionResult 
            //return View(film);
            // return Content("Sex is Good!"); // Returns string content
            // return NotFound();
            // return new EmptyResult(); // If an action doesn't return anything
            //return RedirectToAction("Privacy", "Home", new { page = 1, sortBy = "date" });
        }

        public IActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }

        // Attribute Routing (More modern). colon (:) stands for constraint description rules
        [Route("films/bygenre/{genre:minlength(3)}")]
        public IActionResult ByGenre(string genre) 
        {
            return Content($"you are searching by {genre}");
        }

        // Films. To make a parameter optional, we make it Nullable. In case the string below, we don't need
        // To do anything becase string is a reference type and IS NULLABLE by definition
        public IActionResult Index(int? pageIndex, string sortBy) 
        { 
            if (!pageIndex.HasValue) 
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }
            return Content($"pageIndex = {pageIndex}\n sortBy = {sortBy}");

        }
        // Films/Edit/5
        public IActionResult Edit(int Id)
        {
            return Content($"Id entered equals {Id}");
        }
    }
}
