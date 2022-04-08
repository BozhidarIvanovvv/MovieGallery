using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Movie;
using MovieGalleryApp.Web.Models;
using System.Diagnostics;
using System.Linq;

namespace MovieGalleryApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(
            ILogger<HomeController> logger,
            IMovieService movieService
            )
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var actionMovies = await _movieService.GetMoviesByGenre("Action");
            var fantasyMovies = await _movieService.GetMoviesByGenre("Fantasy");

            var model = new List<IEnumerable<MovieMainPageVM>>() 
            {
                actionMovies.OrderBy(a => Guid.NewGuid()).ToList(),
                fantasyMovies.OrderBy(a => Guid.NewGuid()).ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
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