using MovieGalleryApp.Core.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface IGenreService
    {
        Task<string> GetGenresAsStringById(Guid movieId);

        Task<IEnumerable<GenreTableVM>> GetAllGenres();

        Task AddGenre(GenreAddVM model);
    }
}
