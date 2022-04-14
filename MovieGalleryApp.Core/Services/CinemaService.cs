using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Cinema;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IApplicationDbRepository _repo;

        public CinemaService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCinema(CinemaAddVM model)
        {
            var dbCinema = await _repo
                .All<Cinema>(a => a.Name == model.Name)
                .FirstOrDefaultAsync();

            if (dbCinema != null)
            {
                throw new ArgumentException("This cinema already exists!");
            }

            var cinema = new Cinema()
            {
                Name = model.Name,
                Location = model.Location,
                ImgUrl = model.ImgUrl
            };

            await _repo.AddAsync(cinema);
            _repo.SaveChanges();
        }

        public async Task<IEnumerable<CinemaAllVM>> GetAllCinemas()
            => await _repo
                .All<Cinema>()
                .Select(a => new CinemaAllVM()
                {
                    Name = a.Name,
                    Location = a.Location,
                    ImgUrl = a.ImgUrl
                })
                .OrderBy(a => a.Name)
                .ToListAsync();

        public async Task<string> GetCinemasAsStringById(Guid movieId)
        {
            var movie = await _repo.GetByIdAsync<Movie>(movieId);

            if (movie == null)
            {
                throw new ArgumentException("This movie doesn't exist!");
            }

            var cinemas = await _repo
                .All<MovieCinema>(mc => mc.MovieId == movieId)
                .Select(mc => new CinemaAllVM
                {
                    Name = mc.Cinema.Name,
                    Location = mc.Cinema.Location,
                    ImgUrl = mc.Cinema.ImgUrl
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            if (cinemas.Count == 0)
            {
                throw new ArgumentException($"This movie: {movie.Title} doesn't have any cinemas!");
            }

            string result = String.Empty;

            for (int i = 0; i < cinemas.Count; i++)
            {
                if (cinemas.Count - 1 == i)
                {
                    result += cinemas[i].Name;
                    break;
                }

                result += cinemas[i].Name + "/";
            }

            result = result.TrimEnd();

            result = result.Replace("/", ", ");

            return result;
        }
    }
}
