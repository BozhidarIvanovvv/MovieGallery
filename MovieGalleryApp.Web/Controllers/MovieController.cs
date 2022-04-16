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
        private readonly ICinemaService _cinemaService;

        public MovieController(
            IMovieService movieService,
            IGenreService genreService,
            ICountryService countryService,
            ICinemaService cinemaService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _countryService = countryService;
            _cinemaService = cinemaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            MovieDetailsVM movie = null;
            try
            {
                movie = await _movieService.GetMovieById(Id);

                movie.Genres = await _genreService.GetGenresAsStringById(Id);
                movie.Countries = await _countryService.GetCountriesAsStringById(Id);
                movie.Cinemas = await _cinemaService.GetCinemasAsStringById(Id);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(movie);
            }

            return View(movie);
        }

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Edit(Guid Id)
        {
            MovieEditVM movieForEdit = null;
            try
            {
                movieForEdit = await _movieService.GetMovieForEdit(Id);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(movieForEdit);
            }

            return View(movieForEdit);
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Edit(MovieEditVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            try
            {
                await _movieService.UpdateMovie(model);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(model);
            }

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
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            Guid id = Guid.Empty;

            try
            {
                id = await _movieService.CreateMovie(model);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(model);
            }

            return Redirect($"/Movie/Details/{id}");
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<MovieTableVM> movies = null;

            try
            {
                movies = await _movieService.GetAllMovies();
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(movies);
            }

            return View(movies);
        }
    }
}
