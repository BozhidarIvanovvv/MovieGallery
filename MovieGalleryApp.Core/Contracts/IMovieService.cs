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
        Task<MovieEditVM> GetMovieForEdit(Guid id);
        Task<bool> UpdateMovie(MovieEditVM model);
        Task<Guid> CreateMovie(MovieCreateVM model);
        Task<IEnumerable<MovieTableVM>> GetAllMovies();
        Task<IEnumerable<MovieMainPageVM>> GetAllMoviesFromCountry(string country);
    }
}
