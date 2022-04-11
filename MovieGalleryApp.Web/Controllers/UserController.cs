using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;

namespace MovieGalleryApp.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
