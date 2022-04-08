using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Genre;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IApplicationDbRepository _repo;

        public GenreService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> GetGenresAsStringById(Guid movieId)
        {
            var movie = await _repo.GetByIdAsync<Movie>(movieId);

            if (movie == null)
            {
                throw new ArgumentException("This movie doesn't exist!");
            }

            var genres = await _repo.All<MovieGenre>()
               .Where(mg => mg.MovieId == movieId)
               .Select(mg => new GenreDetailsVM
               {
                   Id = mg.GenreId,
                   Title = mg.Genre.GenreTitle,
               })
               .OrderBy(g => g.Title)
               .ToListAsync();

            if (genres.Count == 0)
            {
                throw new ArgumentException($"This movie: {movieId} doesn't have any genres!");
            }

            string result = String.Empty;

            foreach (var genre in genres) 
            {
                result += genre.Title + " ";
            }

            result = result.TrimEnd();

            result = result.Replace(" ", ", ");

            return result;
        }
    }
}
