using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Models
{
    public class UserRolesVM
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string[] RoleNames { get; set; }
    }
}
