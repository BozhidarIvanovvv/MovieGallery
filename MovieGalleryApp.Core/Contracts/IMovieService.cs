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
        Task<ICollection<MovieMainPageVM>> GetMoviesByGenre(string genre);
        Task<MovieDetailsVM> GetMovieById(Guid id);
        Task<MovieEditVM> GetMovieForEdit(Guid id);
        Task<bool> UpdateMovie(MovieEditVM model);
        Task<Guid> AddMovie(MovieAddVM model);
        Task<ICollection<MovieTableVM>> GetAllMovies();
        Task<ICollection<MovieMainPageVM>> GetAllMoviesFromCountry(string country);
    }
}
