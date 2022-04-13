using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models.Country
{
    public class CountryAllVM
    {
        [Required]
        public string CountryName { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
