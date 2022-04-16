using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Actor
{
    public class ActorCastAddVM
    {
        [Required]
        [StringLength(DatabaseConstants.ActorEntityConstants.FirstNameMaxLength, MinimumLength = DatabaseConstants.ActorEntityConstants.FirstNameMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.ActorMessageConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DatabaseConstants.ActorEntityConstants.FirstNameMaxLength, MinimumLength = DatabaseConstants.ActorEntityConstants.FirstNameMinLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.ActorMessageConstants.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(DatabaseConstants.ActorEntityConstants.ImgUrlMaxLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.ActorMessageConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }
    }
}
