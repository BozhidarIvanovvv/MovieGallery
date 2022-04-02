using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models;
using MovieGalleryApp.Infrastructure.Identity;

namespace MovieGalleryApp.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IUserService _userService;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userService.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await _userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userService.UpdateUser(model);

            return Redirect("/Admin/User/ManageUsers");
        }

        public async Task<IActionResult> Delete(string id) 
        {
            var user = await _userService.GetUserById(id);
            
            await _userManager.DeleteAsync(user);

            if (await _userService.GetUserById(id) == null)
            {
                // Implement Error message!
            }

            return Redirect("/Admin/User/ManageUsers");
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await _userService.GetUserById(id);
            var model = new UserRolesVM()
            {
                UserId = user.Id,
                Name = $"{user.FirstName} {user.LastName}"
            };

            ViewBag.RoleItems = _roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = _userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Administrator"
        //    });

        //    return Ok();
        //}
    }
}
