using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Movie
{
    public class MovieEditVM
    {
        public Guid Id { get; set; }

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
    }
}
