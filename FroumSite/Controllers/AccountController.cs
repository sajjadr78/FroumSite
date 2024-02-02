using FroumSite.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using FroumSite.Data;
using System.Threading.Tasks;
using System.Linq;
using FroumSite.Models.ViewModels;
using FroumSite.Utilities;
using FroumSite.Repositories;

namespace FroumSite.Controllers
{
    public class AccountController : Controller
    {

        private readonly GenericRepository<User> _userRepo;

        public AccountController(GenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        #region Register

        [NoDirectAccess]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel
            {
                Birthday = DateTime.Now
            };

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userRepo.GetAll(u => u.PhoneNumber == register.PhoneNumber).Any())
            {
                ModelState.AddModelError("PhoneNumber", "شماره همراه وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }

            User user = new User()
            {
                Name = register.Name,
                Family = register.Family,
                Birthday = register.Birthday,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber,
                RegisterDate = DateTime.Now,
                Sex = register.Sex,

            };
            //make first user admin
            var isUsersTblEmpty = !_userRepo.GetAll().Any();


            user.IsAdmin = isUsersTblEmpty;


            await _userRepo.AddAsync(user);
            _userRepo.SaveChangesAsync();

            return View("SuccessRegister", register);
        }

        public IActionResult VerifyEmail(string phoneNumber)
        {
            if (_userRepo.GetAll(u => u.PhoneNumber == phoneNumber).Any())
            {
                return Json($"شماره همراه {phoneNumber} تکراری است");
            }

            return Json(true);
        }
        #endregion

        #region Login


        [NoDirectAccess]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userRepo.GetAll()
                .SingleOrDefault(u => u.PhoneNumber == login.PhoneNumber &&
                                      u.Password == login.Password);
            if (user == null)
            {
                ModelState.AddModelError("PhoneNumber", "اطلاعات صحیح نیست");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
                new Claim("Family",user.Family.ToString()),
                new Claim("Sex",user.Sex.ToString()),
                new Claim("Birthday", user.Birthday.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim("RegisterDate", user.RegisterDate.ToString()),
                new Claim("SharedPosts", user.SharedPosts.ToString()),
                new Claim("SharedTopics", user.SharedTopics.ToString()),
                new Claim("Password", user.Password)

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            await HttpContext.SignInAsync(principal, properties);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        #endregion

        public async Task<bool> Logout()
        {
            try
            {
                await HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
