//using MovieGalleryApp.Core.Contracts;
//using MovieGalleryApp.Infrastructure.Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MovieGalleryApp.Core.Services
//{
//    public class GenreService : IGenreService
//    {
//        private readonly IApplicationDbRepository _repo;

//        public GenreService(IApplicationDbRepository repo)
//        {
//            _repo = repo;
//        }

//        public async Task<string> GetGenreIdFromTitle(string genreTitle)
//        {
//            if (!Enum.IsDefined(typeof(Enums.Genre), genreTitle))
//            {
//                throw new ArgumentException("This genre doesn't exist!");
//            }

//            var genreId = await _repo.
//        }
//    }
//}
