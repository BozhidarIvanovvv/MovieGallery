using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Country;
using MovieGalleryApp.Core.Services;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Tests
{
    public class CountryServiceTests
    {
        private ServiceProvider _serviceProvider;
        private InMemoryDbContext _dbcontext;

        [SetUp]
        public async Task Setup()
        {
            _dbcontext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            _serviceProvider = serviceCollection
                .AddSingleton(sp => _dbcontext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<ICountryService, CountryService>()
                .BuildServiceProvider();

            var _repo = _serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(_repo);

        }

        [TearDown]
        public void TearDown()
        {
            _dbcontext.Dispose();
        }

        [Test]
        public async Task AddCountryAddsCountryProperly()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            var country = new CountryAddVM()
            {
                CountryName = "Germany",
                ImgUrl = ""
            };

            await _countryService.AddCountry(country);

            var countries = await _countryService.GetAllCountries();

            Assert.IsTrue(countries.Count == 3);
        }

        [Test]
        public async Task AddCinemaThrowsWhenCinemaWithTheSameNameIsPresent()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            var country = new CountryAddVM()
            {
                CountryName = "Germany",
                ImgUrl = ""
            };

            await _countryService.AddCountry(country);

            Assert.CatchAsync<ArgumentException>(async () => await _countryService.AddCountry(country), "This country already exists!");
        }

        [Test]
        public async Task GetAllCinemasReturnsDataProperly()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            var allCountries = await _countryService.GetAllCountries();

            Assert.IsTrue(allCountries.Count == 2);
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieIsNotPresent()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            Assert.CatchAsync<ArgumentException>(async () => await _countryService.GetCountriesAsStringById(Guid.Empty), "This movie doesn't exist!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieDoesNotHaveAnyCinemas()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            var movie = new Movie()
            {
                MovieId = Guid.Parse("240ca362-e32a-4c4f-88bd-54c3f434c953"),
                Title = "Test Movie",
                Budget = "",
                Description = "",
                ImgUrl = "",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            Assert.CatchAsync<ArgumentException>(async () => await _countryService.GetCountriesAsStringById(movie.MovieId), $"The movie: {movie.Title} doesn't have any countries!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdReturnsDataProperly()
        {
            var _countryService = _serviceProvider.GetService<ICountryService>();

            var countriesAsString = await _countryService.GetCountriesAsStringById(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            var result = "Bulgaria, United States";

            Assert.AreEqual(result, countriesAsString);
        }

        private async Task SeedDbAsync(IApplicationDbRepository _repo)
        {
            var country = new Country()
            {
                CountryName = "Bulgaria",
                ImgUrl = ""
            };

            var country2 = new Country()
            {
                CountryName = "United States",
                ImgUrl = ""
            };

            var movie = new Movie()
            {
                MovieId = Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"),
                Title = "Test Movie",
                Budget = "",
                Description = "",
                ImgUrl = "",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            movie.MovieCountries.Add(
                new MovieCountry()
                {
                    Country = country,
                    CountryId = country.CountryId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            movie.MovieCountries.Add(
                new MovieCountry()
                {
                    Country = country2,
                    CountryId = country2.CountryId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            await _repo.AddAsync(movie);
            await _repo.SaveChangesAsync();
        }
    }
}
