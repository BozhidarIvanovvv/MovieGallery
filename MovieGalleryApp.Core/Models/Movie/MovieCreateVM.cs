using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Movie
{
    public class MovieCreateVM
    {
        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.TitleMaxLength, MinimumLength = DatabaseConstants.MovieEntityConstants.TitleMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.MovieMessageConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.ImgUrlMaxLength, MinimumLength = DatabaseConstants.MovieEntityConstants.TitleMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.MovieMessageConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.DescriptionMaxLength, MinimumLength = DatabaseConstants.MovieEntityConstants.DescriptionMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.MovieMessageConstants.TitleMaxLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.BudgetMaxLength, MinimumLength = DatabaseConstants.MovieEntityConstants.BudgetMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.MovieMessageConstants.TitleMaxLength)]
        public string Budget { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(DatabaseConstants.MovieEntityConstants.RatingMinValue, DatabaseConstants.MovieEntityConstants.BudgetMaxLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.MovieMessageConstants.RatingMaxLength)]
        public double Rating { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Countries { get; set; }

        [Required]
        public string Cinemas { get; set; }
    }
}
