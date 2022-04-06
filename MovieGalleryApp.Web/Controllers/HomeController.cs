using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Web.Models;
using System.Diagnostics;

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
            var moviesByGenre = await _movieService.GetMoviesByGenre("Action");

            return View(moviesByGenre);
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