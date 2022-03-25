using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class Genre
    {
        [Key]
        public Guid GenreId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(DatabaseConstants.GenreEntityConstants.TitleMaxLength)]
        public string GenreTitle { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
