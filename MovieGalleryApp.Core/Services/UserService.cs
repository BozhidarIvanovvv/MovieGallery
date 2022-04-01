using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using MovieGalleryApp.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository _repo;

        public UserService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserEditVM> GetUserForEdit(string id)
        {
            var user = await _repo.GetByIdAsync<ApplicationUser>(id);

            return new UserEditVM() {FirstName = user.FirstName, LastName = user.LastName, Id = user.Id };
        }

        public async Task<IEnumerable<UserListVM>> GetUsers()
        {
            return await _repo
                .All<ApplicationUser>()
                .Select(u => new UserListVM 
                {
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}",
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditVM model)
        {
            bool result = false;
            
            var user = await _repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
