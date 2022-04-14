using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Country;

namespace MovieGalleryApp.Web.Controllers
{
    public class CountryController : BaseController
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IActionResult> All()
        {
            var countries = await _countryService.GetAllCountries();

            return View(countries);
        }

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(CountryAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _countryService.AddCountry(model);

            return Redirect($"/Country/Countries");
        }
    }
}
