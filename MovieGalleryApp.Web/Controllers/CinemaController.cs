using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;

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
    }
}
