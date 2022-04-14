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
            var actors = await _cinemaService.GetAllCinemas();

            return View(actors);
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
                return View(model);
            }

            await _cinemaService.AddCinema(model);

            return Redirect($"/Cinema/All");
        }
    }
}
