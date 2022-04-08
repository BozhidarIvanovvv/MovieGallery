using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class Actor
    {
        [Key]
        public Guid ActorId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(DatabaseConstants.ActorEntityConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DatabaseConstants.ActorEntityConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(DatabaseConstants.MovieEntityConstants.ImgUrlMaxLength)]
        public string ImgUrl { get; set; }
    }
}
