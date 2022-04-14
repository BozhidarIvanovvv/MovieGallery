using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class MovieCinema
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid CinemaId { get; set; }
        public Cinema Cinema { get; set; }
    }
}
