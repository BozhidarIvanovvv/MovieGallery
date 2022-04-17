using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Genre;
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
    public class GenreServiceTests
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
                .AddSingleton<IGenreService, GenreService>()
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
            var _genreService = _serviceProvider.GetService<IGenreService>();

            var genre = new GenreAddVM()
            {
                GenreTitle = "Thriller"
            };

            await _genreService.AddGenre(genre);

            var genres = await _genreService.GetAllGenres();

            Assert.IsTrue(genres.Count == 3);
        }

        [Test]
        public async Task AddCinemaThrowsWhenCinemaWithTheSameNameIsPresent()
        {
            var _genreService = _serviceProvider.GetService<IGenreService>();

            var genre = new GenreAddVM()
            {
                GenreTitle = "Thriller"
            };

            await _genreService.AddGenre(genre);

            Assert.CatchAsync<ArgumentException>(async () => await _genreService.AddGenre(genre), "This genre already exists!");
        }

        [Test]
        public async Task GetAllCinemasReturnsDataProperly()
        {
            var _genreService = _serviceProvider.GetService<IGenreService>();

            var allGeners = await _genreService.GetAllGenres();

            Assert.IsTrue(allGeners.Count == 2);
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieIsNotPresent()
        {
            var _genreService = _serviceProvider.GetService<IGenreService>();

            Assert.CatchAsync<ArgumentException>(async () => await _genreService.GetGenresAsStringById(Guid.Empty), "This movie doesn't exist!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdThrowsWhenMovieDoesNotHaveAnyCinemas()
        {
            var _genreService = _serviceProvider.GetService<IGenreService>();

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

            Assert.CatchAsync<ArgumentException>(async () => await _genreService.GetGenresAsStringById(movie.MovieId), $"The movie: {movie.Title} doesn't have any cinemas!");
        }

        [Test]
        public async Task GetCinemasAsStringByIdReturnsDataProperly()
        {
            var _genreService = _serviceProvider.GetService<IGenreService>();

            var cinemasAsString = await _genreService.GetGenresAsStringById(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            var result = "Action, Adventure";

            Assert.AreEqual(result, cinemasAsString);
        }

        private async Task SeedDbAsync(IApplicationDbRepository _repo)
        {
            var genre = new Genre()
            {
                GenreTitle = "Action"
            };

            var genre2 = new Genre()
            {
                GenreTitle = "Adventure"
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

            movie.MovieGenres.Add(
                new MovieGenre()
                {
                    Genre = genre,
                    GenreId = genre.GenreId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            movie.MovieGenres.Add(
                new MovieGenre()
                {
                    Genre = genre2,
                    GenreId = genre2.GenreId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            await _repo.AddAsync(movie);
            await _repo.SaveChangesAsync();
        }
    }
}
