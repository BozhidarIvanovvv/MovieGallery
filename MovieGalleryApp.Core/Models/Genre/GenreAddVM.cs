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
        public string Title { get; set; }
    }
}
