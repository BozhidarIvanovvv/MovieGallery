using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Country
{
    public class CountryAddVM
    {
        [Required]
        [StringLength(DatabaseConstants.CountryEntityConstants.NameMaxLength, MinimumLength = DatabaseConstants.CountryEntityConstants.NameMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.CountryMessageConstants.NameMaxLength)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(DatabaseConstants.CountryEntityConstants.ImgUrlMaxLength, MinimumLength = DatabaseConstants.CountryEntityConstants.ImgUrlMaxLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.CountryMessageConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }
    }
}
