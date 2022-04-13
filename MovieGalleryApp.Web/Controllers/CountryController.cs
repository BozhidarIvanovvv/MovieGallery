using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Contracts;

namespace MovieGalleryApp.Web.Controllers
{
    public class CountryController : BaseController
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> Countries()
        {
            var countries = await _countryService.GetAllCountries();

            return View(countries);
        }
    }
}
