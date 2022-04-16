using MovieGalleryApp.Core.Models;
using MovieGalleryApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListVM>> GetUsers();
        Task<UserEditVM> GetUserForEdit(string id);
        Task<bool> UpdateUser(UserEditVM model);
        Task<bool> DeleteUser(string id);
        Task<ApplicationUser> GetUserById(string id);
    }
}
