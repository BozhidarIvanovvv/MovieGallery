using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Genre;

namespace MovieGalleryApp.Web.Controllers
{
    public class GenreController : BaseController
    {
        private IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        public async Task<IActionResult> All()
        {
            IEnumerable<GenreTableVM> genres = null;

            try
            {
                genres = await _genreService.GetAllGenres();

            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(genres);
            }

            return View(genres);
        }

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(GenreAddVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            try
            {
                await _genreService.AddGenre(model);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(model);
            }

            return Redirect($"/Genre/Genres");
        }
    }
}
