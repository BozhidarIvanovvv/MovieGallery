using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Enums;
using MovieGalleryApp.Core.Models.Movie;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IApplicationDbRepository _repo;

        public MovieService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> AddMovie(MovieAddVM model)
        {
            var dbMovie = await _repo
                .All<Movie>(a => a.Title == model.Title)
                .FirstOrDefaultAsync();

            if (dbMovie != null)
            {
                throw new ArgumentException("This movie already exists!");
            }

            if (model.Genres == null)
            {
                throw new ArgumentException("This movie has no genres!");
            }

            if (model.Countries == null)
            {
                throw new ArgumentException("This movie has no countries!");
            }

            if (model.Cinemas == null)
            {
                throw new ArgumentException("This movie has no cinemas!");
            }

            var genres = model.Genres.TrimEnd().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var countries = model.Countries.TrimEnd().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var cinemas = model.Cinemas.TrimEnd().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var movie = new Movie
            {
                Title = model.Title,
                Description = model.Description,
                Budget = model.Budget,
                ImgUrl = model.ImgUrl,
                Rating = model.Rating,
                ReleaseDate = model.ReleaseDate,
            };

            foreach (var genre in genres)
            {
                var dbGenre = await _repo
                    .All<Genre>(g => g.GenreTitle == genre)
                    .FirstOrDefaultAsync();

                if (dbGenre == null)
                {
                    throw new ArgumentException("This genre doesn't exist!");
                }

                movie.MovieGenres.Add(new MovieGenre 
                {
                    GenreId = dbGenre.GenreId,
                    Genre = dbGenre,
                    MovieId = movie.MovieId,
                    Movie = movie,
                });
            }

            foreach (var country in countries)
            {
                var dbCountry = await _repo
                    .All<Country>(g => g.CountryName == country)
                    .FirstOrDefaultAsync();

                if (dbCountry == null)
                {
                    throw new ArgumentException("This country doesn't exist!");
                }

                movie.MovieCountries.Add(new MovieCountry
                {
                    CountryId = dbCountry.CountryId,
                    Country = dbCountry,
                    MovieId = movie.MovieId,
                    Movie = movie,
                });
            }

            foreach (var cinema in cinemas)
            {
                var dbCinema = await _repo
                    .All<Cinema>(c => c.Name == cinema)
                    .FirstOrDefaultAsync();

                if (dbCinema == null)
                {
                    throw new ArgumentException("This cinema doesn't exist!");
                }

                movie.MovieCinemas.Add(new MovieCinema
                {
                    CinemaId = dbCinema.CinemaId,
                    Cinema = dbCinema,
                    MovieId = movie.MovieId,
                    Movie = movie,
                });
            }

            await _repo.AddAsync(movie);
            await _repo.SaveChangesAsync();

            return movie.MovieId;
        }

        public async Task<ICollection<MovieTableVM>> GetAllMovies() 
            => await _repo
                .All<Movie>()
                .Select(m => new MovieTableVM
                {
                   Title = m.Title,
                   Budget = m.Budget,
                   ImgUrl = m.ImgUrl,
                   Rating = m.Rating,
                   ReleaseDate = m.ReleaseDate,
                })
                .OrderBy(m => m.Title)
                .ToListAsync();

        public async Task<ICollection<MovieMainPageVM>> GetAllMoviesFromCountry(string country)
            => await _repo
                .All<MovieCountry>(m => m.Country.CountryName == country)
                .Select(m => new MovieMainPageVM
                {
                    Id = m.Movie.MovieId,
                    Title = m.Movie.Title,
                    Description = m.Movie.Description,
                    ImgUrl= m.Movie.ImgUrl
                })
                .Take(8)
                .ToListAsync();
        

        public async Task<MovieDetailsVM> GetMovieById(Guid id)
        {
            var movie = await _repo.GetByIdAsync<Movie>(id);

            if (movie == null)
            {
                throw new ArgumentException("This movie doesn't exist!");
            }

            return new MovieDetailsVM() {
                Id = movie.MovieId.ToString(),
                Title = movie.Title,
                ImgUrl = movie.ImgUrl,
                Budget = movie.Budget,
                Description = movie.Description,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public async Task<MovieEditVM> GetMovieForEdit(Guid id)
        {
            var movie = await _repo.GetByIdAsync<Movie>(id);

            return new MovieEditVM()
            {
                Id = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                Budget = movie.Budget,
                ImgUrl = movie.ImgUrl,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public async Task<ICollection<MovieMainPageVM>> GetMoviesByGenre(string genreTitle)
        {
            if (!Enum.IsDefined(typeof(Enums.GenreEnum), genreTitle))
            {
                throw new ArgumentException("This genre title doesn't exist!");
            }

            var genre = await _repo
                .All<Genre>(g => g.GenreTitle == genreTitle)
                .FirstOrDefaultAsync();

            var movies = await _repo
                .All<MovieGenre>(mg => mg.GenreId == genre.GenreId)
                .Select(mg => new MovieMainPageVM() 
                {
                    Id = mg.MovieId,
                    Title = mg.Movie.Title,
                    Description = mg.Movie.Description,
                    ImgUrl = mg.Movie.ImgUrl,
                })
                .ToArrayAsync();

            return movies;
        }

        public async Task<bool> UpdateMovie(MovieEditVM model)
        {
            bool result = false;

            var movie = await _repo.GetByIdAsync<Movie>(model.Id);

            if (movie != null)
            {
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.Budget = model.Budget;
                movie.ReleaseDate = model.ReleaseDate;
                movie.ImgUrl = model.ImgUrl;

                await _repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
