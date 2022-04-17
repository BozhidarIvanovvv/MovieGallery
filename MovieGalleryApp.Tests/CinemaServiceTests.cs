using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Cinema;
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
    public class CinemaServiceTests
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
                .AddSingleton<ICinemaService, CinemaService>()
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
        public async Task AddCinemaAddsCinemaProperly()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();

            var cinema = new CinemaAddVM()
            {
                Name = "Test 3",
                Location = "",
                ImgUrl = ""
            };

            await _cinemaService.AddCinema(cinema);

            var cinemas = await _cinemaService.GetAllCinemas();

            Assert.IsTrue(cinemas.Count == 3);
        }

        [Test]
        public async Task AddCinemaThrowsWhenCinemaWithTheSameNameIsPresent()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();

            var cinema = new CinemaAddVM()
            {
                Name = "Test 3",
                Location = "",
                ImgUrl = ""
            };

            await _cinemaService.AddCinema(cinema);

            Assert.CatchAsync<ArgumentException>(async () => await _cinemaService.AddCinema(cinema), "This cinema already exists!");
        }

        [Test]
        public async Task GetAllCinemasReturnsDataProperly()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();
           
            var allCinemas = await _cinemaService.GetAllCinemas();

            Assert.IsTrue(allCinemas.Count == 2);
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieIsNotPresent()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();

            Assert.CatchAsync<ArgumentException>(async () => await _cinemaService.GetCinemasAsStringById(Guid.Empty), "This movie doesn't exist!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieDoesNotHaveAnyCinemas()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();

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

            Assert.CatchAsync<ArgumentException>(async () => await _cinemaService.GetCinemasAsStringById(movie.MovieId), $"The movie: {movie.Title} doesn't have any cinemas!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdReturnsDataProperly()
        {
            var _cinemaService = _serviceProvider.GetService<ICinemaService>();

            var cinemasAsString = await _cinemaService.GetCinemasAsStringById(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            var result = "Test 1, Test 2";

            Assert.AreEqual(result, cinemasAsString);
        }

        private async Task SeedDbAsync(IApplicationDbRepository _repo)
        {
            var cinema = new Cinema()
            {
                Name = "Test 1",
                Location = "",
                ImgUrl = ""
            };

            var cinema2 = new Cinema()
            {
                Name = "Test 2",
                Location = "",
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

            movie.MovieCinemas.Add(
                new MovieCinema()
                {
                    Cinema = cinema,
                    CinemaId = cinema.CinemaId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            movie.MovieCinemas.Add(
                new MovieCinema()
                {
                    Cinema = cinema2,
                    CinemaId = cinema2.CinemaId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            await _repo.AddAsync(movie);
            await _repo.SaveChangesAsync();
        }
    }
}
