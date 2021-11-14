using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Web.Models;
using UserManagement.Web.Services;

namespace UserManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashbordController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public DashbordController(IUserService userService , SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string username)
        {
            AppUser user = await _userService.GetByUserName(username);
            if (user==null)
            {
                return View("Get");
            }
            UserShowDto userShowDto = new UserShowDto
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id
            };
            return View(userShowDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userService.GetById(id);
            UserShowDto userShowDto = new UserShowDto
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id
            };
            return View(userShowDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserShowDto model)
        {
            AppUser user = await _userService.GetById(model.Id.ToString());
            user.Address = model.Address;
            user.DateOfBirth = model.DateOfBirth;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.Gender = model.Gender;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            IdentityResult result = await _userService.EditUser(user);
            if (result.Succeeded)
                return RedirectToAction("GetAllUsers");
            else
                return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            AppUser user = await _userService.GetById(id);
            UserShowDto userShowDto = new UserShowDto
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id
            };
            return View(userShowDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Remove(id);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<AppUser> allUsers = await _userService.GetAll();

            List<UserShowDto> users = new List<UserShowDto>();
            foreach (AppUser item in allUsers)
            {
                users.Add(new UserShowDto
                {
                    Address = item.Address,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    Gender = item.Gender,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    UserName = item.UserName,
                    Id = item.Id
                });
            }
            return View("ShowList", users);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home" , new { area = "" });
        }
    }
}
