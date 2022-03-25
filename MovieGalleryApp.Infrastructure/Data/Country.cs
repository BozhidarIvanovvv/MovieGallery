using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(DatabaseConstants.CountryEntityConstants.NameMaxLength)]
        public string CountryName { get; set; }

        public ICollection<MovieCountry> MovieCountries { get; set; } = new List<MovieCountry>();
    }
}
