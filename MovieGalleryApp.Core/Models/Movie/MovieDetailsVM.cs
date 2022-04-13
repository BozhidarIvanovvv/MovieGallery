using MovieGalleryApp.Core.Models.Genre;
using System.ComponentModel.DataAnnotations;

namespace MovieGalleryApp.Core.Models.Movie
{
    public class MovieDetailsVM
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Budget { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Countries { get; set; }
    }
}
