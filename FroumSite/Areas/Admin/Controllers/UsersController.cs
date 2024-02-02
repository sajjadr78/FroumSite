using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using FroumSite.Models.ViewModels;
using FroumSite.Utilities;
using System.Collections.Generic;

namespace FroumSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly FroumContext _context;
        private static int _userIdToEdit = 0;
        private static int _userIdToDelete = 0;
        public UsersController(FroumContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            RegisterViewModel vm = new RegisterViewModel
            {
                RegisterDate = new System.DateTime(1950, 1, 1),
                Birthday = new System.DateTime(1950, 1, 1)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(RegisterViewModel vm)
        {
            if (_userIdToEdit == 0)
            {
                var isUserExists = _context.Users
                                    .Any(u => u.PhoneNumber == vm.PhoneNumber);
                if (isUserExists)
                {
                    ModelState.AddModelError("PhoneNumber", "این شماره تلفن از قبل ثبت نام کرده است");
                    return View("Create");
                }

                User user = new User
                {
                    Birthday = vm.Birthday,
                    Family = vm.Family,
                    IsAdmin = vm.IsAdmin,
                    Name = vm.Name,
                    PhoneNumber = vm.PhoneNumber,
                    RegisterDate = vm.RegisterDate,
                    Password = vm.Password,
                    Sex = vm.Sex
                };

                _context.Users.Add(user);
            }
            else
            {
                var userToEdit = await _context.Users
                    .FirstOrDefaultAsync(p => p.Id == _userIdToEdit);

                if (userToEdit != null)
                {
                    userToEdit.Name = vm.Name;
                    userToEdit.Family = vm.Family;
                    userToEdit.PhoneNumber = vm.PhoneNumber;
                    userToEdit.Birthday = vm.Birthday;
                    userToEdit.RegisterDate = vm.RegisterDate;
                    userToEdit.Password = vm.Password;
                    userToEdit.Sex = vm.Sex;
                    userToEdit.IsAdmin = vm.IsAdmin;
                }
            }


            await _context.SaveChangesAsync();

            _userIdToEdit = 0;

            var model = await _context.Users.ToListAsync();

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_UsersPartial", model) };

            return Json(json);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _userIdToDelete = id;

            var userToDelete = await _context.Users
                .FirstOrDefaultAsync(p => p.Id == id);


            return View(userToDelete);
        }

        public IActionResult Edit(int id)
        {
            _userIdToEdit = id;

            var userToEdit = _context.Users.Find(id);

            User user = new User
            {
                Name = userToEdit.Name,
                Family = userToEdit.Family,
                PhoneNumber = userToEdit.PhoneNumber,
                Sex = userToEdit.Sex,
                Birthday = userToEdit.Birthday,
                RegisterDate = userToEdit.RegisterDate,
                IsAdmin = userToEdit.IsAdmin,
                Password = userToEdit.Password
            };

            return View(userToEdit);
        }

        public IActionResult Details(int id)
        {
            var userToShowDetails = _context.Users
                .FirstOrDefault(o => o.Id == id);


            return View(userToShowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            try
            {
                var userToDelete = await _context.Users
                    .Include(p=>p.SharedPosts)
                    .Include(t=>t.SharedTopics)
                    .FirstOrDefaultAsync(u=>u.Id==_userIdToDelete);

                var hasAnyTopicsOrPosts = userToDelete.SharedPosts.Any() || 
                                          userToDelete.SharedTopics.Any(); ;

                if (hasAnyTopicsOrPosts)
                {
                    var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
    "این کاربر دارای پست ها یا تاپیک هایی می باشد بنابراین نمی توان آنرا حذف نمود" +
    "</h3>";
                    var jsonResult = new { isValid = false, error = errorTag };

                    return Json(jsonResult);
                }


                _context.Users.Remove(userToDelete);

                var a = _context.SaveChangesAsync().Result;

                var users = await _context.Users.ToListAsync();

                var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_UsersPartial", users) };
                return Json(json);

            }
            catch
            {
                var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                               "خطا!" +
                               "</h3>";

                var jsonResult = new { isValid = false, error = errorTag };

                return Json(jsonResult);
            }

        }
    }
}
