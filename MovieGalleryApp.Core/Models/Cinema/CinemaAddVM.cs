using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Cinema
{
    public class CinemaAddVM
    {
        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.NameMaxLength, MinimumLength = DatabaseConstants.CinemaEntityConstants.NameMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.CinemaMessageConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.ImgUrlMaxLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.CinemaMessageConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }

        [Required]
        [StringLength(DatabaseConstants.CinemaEntityConstants.LocationNameMaxLength, MinimumLength = DatabaseConstants.CinemaEntityConstants.LocationNameMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.CinemaMessageConstants.LocationMaxLength)]
        public string Location { get; set; }
    }
}
