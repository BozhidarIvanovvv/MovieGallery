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
        private readonly ICountryService _countryService;

        public MovieController(
            IMovieService movieService,
            IGenreService genreService,
            ICountryService countryService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var movie = await _movieService.GetMovieById(Id);

            movie.Genres = await _genreService.GetGenresAsStringById(Id);
            movie.Countries = await _countryService.GetCountriesAsStringById(Id);

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

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(MovieCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = await _movieService.CreateMovie(model);

            return Redirect($"/Movie/Details/{id}");
        }

        public async Task<IActionResult> Movies()
        {
            var movies = await _movieService.GetAllMovies();

            return View(movies);
        }
    }
}
