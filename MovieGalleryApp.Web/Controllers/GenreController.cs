using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;

namespace MovieGalleryApp.Web.Controllers
{
    public class GenreController : BaseController
    {
        private IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        public async Task<IActionResult> Genres()
        {
            var genres = await _genreService.GetAllGenres();
            
            return View(genres);
        }
    }
}
