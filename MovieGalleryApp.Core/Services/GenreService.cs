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

        public async Task<ICollection<GenreTableVM>> GetAllGenres()
            =>  await _repo
                    .All<Genre>()
                    .Select(g => new GenreTableVM
                    {
                        Title = g.GenreTitle
                    })
                    .OrderBy(g => g.Title)
                    .ToListAsync();

        public async Task<string> GetGenresAsStringById(Guid movieId)
        {
            var movie = await _repo.GetByIdAsync<Movie>(movieId);

            if (movie == null)
            {
                throw new ArgumentException("This movie doesn't exist!");
            }

            var genres = await _repo
                .All<MovieGenre>(mg => mg.MovieId == movieId)
                .Select(mg => new GenreDetailsVM
                {
                    Id = mg.GenreId,
                    Title = mg.Genre.GenreTitle,
                })
                .OrderBy(g => g.Title)
                .ToListAsync();

            if (genres.Count == 0)
            {
                throw new ArgumentException($"The movie: {movie.Title} doesn't have any genres!");
            }

            string result = String.Empty;

            for (int i = 0; i < genres.Count; i++)
            {
                if (genres.Count - 1 == i)
                {
                    result += genres[i].Title;
                    break;
                }

                result += genres[i].Title + "/";
            }

            result = result.TrimEnd();

            result = result.Replace("/", ", ");

            return result;
        }

        public async Task AddGenre(GenreAddVM model)
        {
            var dbGenre = await _repo
                .All<Genre>(a => a.GenreTitle == model.GenreTitle)
                .FirstOrDefaultAsync();

            if (dbGenre != null)
            {
                throw new ArgumentException("This genre already exists!");
            }

            var genre = new Genre()
            {
                GenreTitle = model.GenreTitle,
            };

            await _repo.AddAsync(genre);
            await _repo.SaveChangesAsync();
        }
    }
}
