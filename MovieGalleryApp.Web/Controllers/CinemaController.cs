using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Cinema;

namespace MovieGalleryApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<CinemaAllVM> cinemas = null;

            try
            {
                cinemas = await _cinemaService.GetAllCinemas();
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(cinemas);
            }

            return View(cinemas);
        }

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(CinemaAddVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            try
            {
                await _cinemaService.AddCinema(model);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(model);
            }

            return Redirect($"/Cinema/All");
        }
    }
}
