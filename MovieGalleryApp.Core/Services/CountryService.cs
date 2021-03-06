using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Country;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IApplicationDbRepository _repo;

        public CountryService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCountry(CountryAddVM model)
        {
            var dbCountry = await _repo
                .All<Country>(a => a.CountryName == model.CountryName)
                .FirstOrDefaultAsync();

            if (dbCountry != null)
            {
                throw new ArgumentException(ServiceConstants.CountryServiceConstants.CountryAlreadyExsist);
            }

            var country = new Country()
            {
                CountryName = model.CountryName,
                ImgUrl = model.ImgUrl
            };

            await _repo.AddAsync(country);
            await _repo.SaveChangesAsync();
        }

        public async Task<ICollection<CountryAllVM>> GetAllCountries()
            => await _repo
                .All<Country>()
                .Select(c => new CountryAllVM()
                {
                    CountryName = c.CountryName,
                    ImgUrl = c.ImgUrl
                })
                .OrderBy(c => c.CountryName)
                .ToListAsync();

        public async Task<string> GetCountriesAsStringById(Guid movieId)
        {
            var movie = await _repo.GetByIdAsync<Movie>(movieId);

            if (movie == null)
            {
                throw new ArgumentException(ServiceConstants.MovieServiceConstants.MovieDoesNotExsist);
            }

            var countries = await _repo
                .All<MovieCountry>(mc => mc.MovieId == movieId)
                .Select(mc => new CountryDetailsVM
                {
                    Id = mc.CountryId,
                    CountryName = mc.Country.CountryName,
                })
                .OrderBy(g => g.CountryName)
                .ToListAsync();

            if (countries.Count == 0)
            {
                throw new ArgumentException(ServiceConstants.CountryServiceConstants.MovieDoesNotHaveAnyCountries, movie.Title);
            }

            string result = String.Empty;

            for (int i = 0; i < countries.Count; i++)
            {
                if (countries.Count - 1 == i)
                {
                    result += countries[i].CountryName;
                    break;
                }

                result += countries[i].CountryName + "/";
            }

            result = result.TrimEnd();

            result = result.Replace("/", ", ");

            return result;
        }
    }
}
