using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;

namespace MovieGalleryApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MovieController(
            IMovieService movieService,
            IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var movie = await _movieService.GetMovieById(Id);

            movie.Genres = await _genreService.GetGenresAsStringById(Id);

            return View(movie);
        }
    }
}
