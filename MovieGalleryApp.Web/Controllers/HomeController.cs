using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
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
            IEnumerable<MovieMainPageVM> actionMovies = null;
            IEnumerable<MovieMainPageVM> fantasyMovies = null;

            try
            {
                actionMovies = await _movieService.GetMoviesByGenre("Action");
                fantasyMovies = await _movieService.GetMoviesByGenre("Fantasy");
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View();
            }

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

        public async Task<IActionResult> GetData() 
        {
            IEnumerable<MovieMainPageVM> movies = null;

            try
            {
                movies = await _movieService.GetAllMoviesFromCountry("United States");
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View();
            }

            return Json(movies);
        }
    }
}