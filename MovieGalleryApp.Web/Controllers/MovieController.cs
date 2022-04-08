using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;

namespace MovieGalleryApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var movie = await _movieService.GetMovieById(Id);

            return View(movie);
        }
    }
}
