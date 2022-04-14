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
    }
}
