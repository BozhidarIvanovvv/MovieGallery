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

        public async Task<IEnumerable<MovieMainPageVM>> GetMoviesByGenre(string genreTitle)
        {
            if (!Enum.IsDefined(typeof(Enums.Genre), genreTitle))
            {
                throw new ArgumentException("This genre title doesn't exist!");
            }

            var genre = await _repo.All<Infrastructure.Data.Genre>()
                .FirstOrDefaultAsync(g => g.GenreTitle == genreTitle);

            if (genre == null) 
            {
                throw new ArgumentException("This genre doesn't exist!");
            }

            var movies = await _repo.All<MovieGenre>()
                .Where(mg => mg.GenreId == genre.GenreId)
                .Select(mg => new MovieMainPageVM 
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
