using Microsoft.AspNetCore.Identity;
using MovieGalleryApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(ApplicationUserConstants.FirstNameMaxLength)]
        public string? FirstName { get; set; }
        
        [StringLength(ApplicationUserConstants.LastNameMaxLength)]
        public string? LastName { get; set; }
    }
}
