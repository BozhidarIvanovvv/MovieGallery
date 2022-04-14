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
        Task<IEnumerable<CinemaAllVM>> GetAllCinemas();

        Task AddCinema(CinemaAddVM model);
    }
}
