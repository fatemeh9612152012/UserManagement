using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagement.Web.Models;
using UserManagement.Web.Services;

namespace UserManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userService.GetByUserName(request.UserName);
                if (userCheck == null)
                {
                    IdentityResult result = await _userService.InsertUser(request.UserName, request.Email, request.PhoneNumber, request.FirstName, request.LastName, request.DateOfBirth, request.Address, request.Gender, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "نام کاربری وجود دارد");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            return View(userLoginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = _userService.GetByUserName(model.Username).Result;

                if (user == null)
                {
                    ModelState.AddModelError("message", "کاربر یافت نشد");
                    return View(model);

                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "کلمه عبور صحیح نیست");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "Dashbord",  new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("message", "نام کاربری یا کلمه عبور معتبر نیست");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
