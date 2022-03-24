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
        [StringLength(MovieEntityConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(MovieEntityConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(MovieEntityConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(MovieEntityConstants.BudgetMaxLength)]
        public string Budget { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(MovieEntityConstants.RatingMinValue, MovieEntityConstants.RatingMaxValue)]
        public double Rating { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieCountry> MovieCountries { get; set; } = new List<MovieCountry>();
    }
}
