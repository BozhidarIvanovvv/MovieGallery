using MovieGalleryApp.Core.Models.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface ICinemaService
    {
        Task<ICollection<CinemaAllVM>> GetAllCinemas();
        Task AddCinema(CinemaAddVM model);
        Task<string> GetCinemasAsStringById(Guid movieId);
    }
}
