using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using FroumSite.Models.ViewModels;

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

            return RedirectToAction("Users", "Home");
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
            var userToDelete = _context.Users.Find(_userIdToDelete);

            _context.Users.Remove(userToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction("Users", "Home");
        }
    }
}
