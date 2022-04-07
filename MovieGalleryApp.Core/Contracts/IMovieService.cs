using MovieGalleryApp.Core.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface IMovieService 
    {
        Task<IEnumerable<MovieMainPageVM>> GetMoviesByGenre(string genre);

        Task<MovieDetailsVM> GetMovieById(Guid id);
    }
}
