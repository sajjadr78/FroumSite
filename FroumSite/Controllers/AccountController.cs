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

namespace FroumSite.Controllers
{
    public class AccountController : Controller
    {

        private readonly FroumContext _context;

        public AccountController(FroumContext context)
        {
            _context = context;
        }
        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_context.Users.Any(u => u.PhoneNumber == register.PhoneNumber))
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

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return View("SuccessRegister", register);
        }

        public IActionResult VerifyEmail(string phoneNumber)
        {
            if (_context.Users.Any(u => u.PhoneNumber == phoneNumber))
            {
                return Json($"شماره همراه {phoneNumber} تکراری است");
            }

            return Json(true);
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _context.Users
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

                // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }

    }
}
