using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Web.Models;

namespace UserManagement.Web.Services
{
    public interface IUserService
    {
        Task<AppUser> GetByUserName(string userName);
        Task<AppUser> GetById(string id);
        Task<List<AppUser>> GetAll();
        Task<IdentityResult> InsertUser(string userName, string email, string phoneNumber, string firstName, string lastName, DateTime dateOfBirth, string address, GenderType gender, string password);
        Task Remove(string id);
        Task<IdentityResult> EditUser(AppUser user);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> GetByUserName(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            return user;
        }
        public async Task<IdentityResult> InsertUser(string userName, string email, string phoneNumber, string firstName, string lastName, DateTime dateOfBirth, string address, GenderType gender, string password)
        {
            var user = new AppUser
            {
                UserName = userName,
                NormalizedUserName = email,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Address = address,
                Gender = gender
            };
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> EditUser(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }
        public async Task<AppUser> GetById(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task<List<AppUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task Remove(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }
    }
}
