using MovieGalleryApp.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models
{
    public class UserEditVM
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = UserConstants.UserEditVMConstants.FirstName)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = UserConstants.UserEditVMConstants.LastName)]
        public string? LastName { get; set; }
    }
}
