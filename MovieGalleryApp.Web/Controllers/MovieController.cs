using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Movie;

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

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var movieForEdit = await _movieService.GetMovieForEdit(Id);

            return View(movieForEdit);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Edit(MovieEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _movieService.UpdateMovie(model);

            return Redirect($"/Movie/Details/{model.Id}");
        }
    }
}
