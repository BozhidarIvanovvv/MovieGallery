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
            IEnumerable<CountryAllVM> countries = null;

            try
            {
                countries = await _countryService.GetAllCountries();

            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(countries);
            }

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
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            try
            {
                await _countryService.AddCountry(model);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View(model);
            }

            return Redirect($"/Country/Countries");
        }
    }
}
