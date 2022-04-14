using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class Cinema
    {
        [Key]
        public Guid CinemaId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.LocationNameMaxLength)]
        public string Location { get; set; }

        public ICollection<MovieCinema> MovieCinemas { get; set; } = new List<MovieCinema>();
    }
}
