using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FroumSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private readonly FroumContext _context;
        private static int _roomIdToEdit = 0;
        private static int _roomIdToDelete = 0;
        public RoomsController(FroumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var subjects = await _context.Subjects.ToListAsync();
            RoomsViewModel vm = new RoomsViewModel
            {
                Subjects = subjects
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(RoomsViewModel vm)
        {
            if (_roomIdToEdit == 0)
            {
                Room room = new Room
                {
                    SubjectId = vm.SubjectId,
                    Title = vm.RoomTitle
                };

                _context.Rooms.Add(room);
            }
            else
            {
                var roomToEdit = await _context.Rooms
                    .FirstOrDefaultAsync(p => p.Id == _roomIdToEdit);

                if (roomToEdit != null)
                {
                    roomToEdit.SubjectId = vm.SubjectId;
                    roomToEdit.Title = vm.RoomTitle;
                }
            }


            await _context.SaveChangesAsync();

            _roomIdToEdit = 0;

            var rooms = await _context.Rooms
                .Include(r => r.Subject)
                .ToListAsync();

            RoomsViewModel roomsViewModel = new RoomsViewModel
            {
                Rooms = rooms
            };

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_RoomsPartial", roomsViewModel) };

            return Json(json);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _roomIdToDelete = id;

            var roomToDelete = await _context.Rooms
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(p => p.Id == id);



            RoomsViewModel vm = new RoomsViewModel
            {
                RoomTitle = roomToDelete.Title,
                SubjectTitle = roomToDelete.Subject.Title,
                Id = id
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            _roomIdToEdit = id;

            var roomToEdit = _context.Rooms.Find(id);
            var subjects = await _context.Subjects.ToListAsync();

            RoomsViewModel vm = new RoomsViewModel
            {
                SubjectId = roomToEdit.SubjectId,
                RoomTitle = roomToEdit.Title,
                Subjects = subjects,
                Id = _roomIdToEdit
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var roomToShowDetails = _context.Rooms
                .Include(u => u.Subject)
                .FirstOrDefault(o => o.Id == id);


            RoomsViewModel vm = new RoomsViewModel
            {
                Id = id,
                RoomTitle = roomToShowDetails.Title,
                SubjectTitle = roomToShowDetails.Subject.Title
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            try
            {
                var roomToDelete = _context.Rooms
                    .Include(t => t.Topics)
                    .FirstOrDefault(r => r.Id == _roomIdToDelete);

                var hasAnyTopics = roomToDelete.Topics.Any();

                if (hasAnyTopics)
                {
                    var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                    "این تالار دارای تاپیک هایی می باشد بنابراین نمی توان آنرا حذف نمود" +
                    "</h3>";
                    var jsonResult = new { isValid = false, error = errorTag };

                    return Json(jsonResult);
                }

                _context.Rooms.Remove(roomToDelete);

                await _context.SaveChangesAsync();

                var rooms = await _context.Rooms
                    .Include(r => r.Subject)
                    .ToListAsync();

                RoomsViewModel roomsViewModel = new RoomsViewModel
                {
                    Rooms = rooms
                };

                var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_RoomsPartial", roomsViewModel) };

                return Json(json);
            }
            catch
            {
                var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                    "خطا!" +
                    "</h3>";
                var json = new { isValid = false, error = errorTag };

                return Json(json);
            }
        }
    }
}
