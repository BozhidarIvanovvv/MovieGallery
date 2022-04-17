using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Movie;
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
    public class MovieServiceTests
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
                .AddSingleton<IMovieService, MovieService>()
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
        public async Task AddMovieAddsMovieProperly()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movie = new MovieAddVM()
            {
                Title = "Test Movie 2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
                Cinemas = "",
                Countries = "",
                Genres = ""
            };

            await _movieService.AddMovie(movie);

            var movies = await _movieService.GetAllMovies();

            Assert.IsTrue(movies.Count == 6);
        }

        [Test]
        public async Task AddMovieAddsThrowsWhenGenresIsNotPresentInDb()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movie = new MovieAddVM()
            {
                Title = "Test Movie 2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
                Cinemas = "A",
                Countries = "A"
            };

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.AddMovie(movie), "This genre doesn't exist!");
        }

        [Test]
        public async Task AddMovieAddsThrowsWhenCountriesIsNotPresentInDb()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movie = new MovieAddVM()
            {
                Title = "Test Movie 2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
                Genres = "A",
                Cinemas = "A"
            };

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.AddMovie(movie), "This country doesn't exist!");
        }

        [Test]
        public async Task AddMovieAddsThrowsWhenCinemasIsNotPresentInDb()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movie = new MovieAddVM()
            {
                Title = "Test Movie 2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
                Genres = "A",
                Countries = "A"
            };

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.AddMovie(movie), "This cinema doesn't exist!");
        }

        [Test]
        public async Task AddMovieThrowsWhenMovieWithTheSameNameIsPresent()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movie = new MovieAddVM()
            {
                Title = "Test",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.AddMovie(movie), "This movie already exists!");
        }

        [Test]
        public async Task GetAllMoviesReturnsDataProperly()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var allMovies = await _movieService.GetAllMovies();

            Assert.IsTrue(allMovies.Count == 5);
        }

        [Test]
        public async Task GetAllMoviesFromCountryReturnsDataProperly()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var moviesFromBulgaria = await _movieService.GetAllMoviesFromCountry("Bulgaria");

            Assert.IsTrue(moviesFromBulgaria.Count == 2);
        }

        [Test]
        public async Task GetMovieByIdThrowsWhenIdIsEmpty()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.GetMovieById(Guid.Empty), "This movie doesn't exist!");
        }

        [Test]
        public async Task GetMovieByIdReturnsProperData()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movieResult = new MovieDetailsVM()
            {
                Title = "Test",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var movie = await _movieService.GetMovieById(Guid.Parse("62b97ef3-2be8-4918-b9fc-97de0069ff6c"));

            Assert.IsTrue(movieResult.Title == movie.Title);
        }

        [Test]
        public async Task GetMovieForEditReturnsProperData()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movieResult = new MovieEditVM()
            {
                Title = "Test",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var movie = await _movieService.GetMovieForEdit(Guid.Parse("62b97ef3-2be8-4918-b9fc-97de0069ff6c"));

            Assert.IsTrue(movieResult.Title == movie.Title);
        }
        

        [Test]
        public async Task GetMoviesByGenreThrowsWhenGenreIsNotPresentInDb()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            Assert.CatchAsync<ArgumentException>(async () => await _movieService.GetMoviesByGenre(""), "This genre title doesn't exist!");
        }

        [Test]
        public async Task GetMoviesByGenreReturnsDataProperly()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var moviesByGenre = await _movieService.GetMoviesByGenre("Adventure");

            Assert.IsTrue(moviesByGenre.Count == 2);
        }

        [Test]
        public async Task UpdateMovieReturnsTrueWhenMovieIsUpdatedSuccessfully()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movieEdit = new MovieEditVM()
            {
                Id = Guid.Parse("62b97ef3-2be8-4918-b9fc-97de0069ff6c"),
                Title = "1",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            Assert.IsTrue(await _movieService.UpdateMovie(movieEdit));
        }

        [Test]
        public async Task UpdateMovieReturnsFalseWhenMovieIsIdIsEmpty()
        {
            var _movieService = _serviceProvider.GetService<IMovieService>();

            var movieEdit = new MovieEditVM()
            {
                Id = Guid.Empty,
                Title = "1",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            Assert.IsFalse(await _movieService.UpdateMovie(movieEdit));
        }

        private async Task SeedDbAsync(IApplicationDbRepository _repo)
        {
            var movie = new Movie()
            {
                MovieId = Guid.Parse("62b97ef3-2be8-4918-b9fc-97de0069ff6c"),
                Title = "Test",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var movieC1 = new Movie()
            {
                MovieId = Guid.Parse("2474ccd6-6034-4c5d-8644-0875e96aa6e3"),
                Title = "c1",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var movieC2 = new Movie()
            {
                MovieId = Guid.Parse("794862cd-e7b1-43fb-97db-a3f98f614e6d"),
                Title = "c2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var country = new Country()
            {
                CountryName = "Bulgaria",
                ImgUrl = "1",
            };
            
            movieC1.MovieCountries.Add(new MovieCountry
            {
                Movie = movieC1,
                MovieId = movieC1.MovieId,
                Country = country,
                CountryId = country.CountryId
            });

            movieC2.MovieCountries.Add(new MovieCountry
            {
                Movie = movieC2,
                MovieId = movieC2.MovieId,
                Country = country,
                CountryId = country.CountryId
            });

            var movieG1 = new Movie()
            {
                MovieId = Guid.Parse("d02a8bc5-057e-4385-9df3-9444ca202ba1"),
                Title = "c1",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var movieG2 = new Movie()
            {
                MovieId = Guid.Parse("29f4293b-1a60-40de-8596-49c85699754a"),
                Title = "c2",
                Budget = "1",
                Description = "1",
                ImgUrl = "1",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            var genre = new Genre()
            {
                GenreTitle = "Adventure"
            };

            movieG1.MovieGenres.Add(new MovieGenre
            {
                Movie = movieC1,
                MovieId = movieC1.MovieId,
                Genre = genre,
                GenreId = genre.GenreId
            });

            movieG2.MovieGenres.Add(new MovieGenre
            {
                Movie = movieG2,
                MovieId = movieG2.MovieId,
                Genre = genre,
                GenreId = genre.GenreId
            });

            await _repo.AddAsync(movie);
            await _repo.AddAsync(movieC1);
            await _repo.AddAsync(movieC2);
            await _repo.AddAsync(movieG1);
            await _repo.AddAsync(movieG2);
            await _repo.SaveChangesAsync();
        }
    }
}
