using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
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

            return RedirectToAction("Rooms", "Home");
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
                SubjectTitle = roomToDelete.Subject.Title
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
                Subjects = subjects
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
            var roomToDelete = _context.Rooms.Find(_roomIdToDelete);

            _context.Rooms.Remove(roomToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction("Rooms", "Home");
        }
    }
}
