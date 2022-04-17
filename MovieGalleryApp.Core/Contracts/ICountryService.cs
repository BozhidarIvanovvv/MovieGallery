using MovieGalleryApp.Core.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface ICountryService
    {
        Task<string> GetCountriesAsStringById(Guid movieId);
        Task<ICollection<CountryAllVM>> GetAllCountries();
        Task AddCountry(CountryAddVM model);
    }
}
