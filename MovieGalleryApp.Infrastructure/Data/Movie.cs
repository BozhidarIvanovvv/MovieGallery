using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; } = Guid.NewGuid();
    
        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.BudgetMaxLength)]
        public string Budget { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(DatabaseConstants.MovieEntityConstants.RatingMinValue,
            DatabaseConstants.MovieEntityConstants.RatingMaxValue)]
        public double Rating { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieCountry> MovieCountries { get; set; } = new List<MovieCountry>();
    }
}
