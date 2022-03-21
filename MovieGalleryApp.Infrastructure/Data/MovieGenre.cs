using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class MovieGenre
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
