using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Genre
{
    public class GenreAddVM
    {
        [Required]
        [StringLength(DatabaseConstants.GenreEntityConstants.TitleMaxLength, MinimumLength = DatabaseConstants.GenreEntityConstants.TitleMinxLength,
            ErrorMessage = DatabaseConstants.ErrorMessageConstants.GenreMessageConstants.NameMaxLength)]
        public string Title { get; set; }
    }
}
