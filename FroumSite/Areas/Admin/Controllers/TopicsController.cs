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
    public class TopicsController : Controller
    {
        private readonly FroumContext _context;
        private static int _topicIdToEdit = 0;
        private static int _topicIdToDelete = 0;
        public TopicsController(FroumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var rooms = await _context.Rooms.ToListAsync();
            var users = await _context.Users.ToListAsync();
            TopicsViewModel vm = new TopicsViewModel
            {
                Rooms = rooms,
                Users = users,

            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TopicsViewModel vm)
        {
            if (_topicIdToEdit == 0)
            {
                Topic topic = new Topic
                {
                    Description = vm.Description,
                    RoomId = vm.RoomId,
                    UserId = vm.UploaderId,
                    Title = vm.Title
                };

                _context.Topics.Add(topic);
            }
            else
            {
                var topicToEdit = await _context.Topics
                    .FirstOrDefaultAsync(p => p.Id == _topicIdToEdit);

                if (topicToEdit != null)
                {
                    topicToEdit.UserId = vm.UploaderId;
                    topicToEdit.RoomId = vm.RoomId;
                    topicToEdit.Description = vm.Description;
                    topicToEdit.Title = vm.Title;
                }
            }


            await _context.SaveChangesAsync();

            _topicIdToEdit = 0;

            return RedirectToAction("Topics", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            _topicIdToDelete = id;

            var topicToDelete = await _context.Topics
                .Include(t => t.Room)
                .Include(u => u.Uploader)
                .FirstOrDefaultAsync(p => p.Id == id);



            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToDelete.Title,
                Description = topicToDelete.Description,
                RoomName = topicToDelete.Room.Title,
                UploaderName = topicToDelete.Uploader.Name
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            _topicIdToEdit = id;

            var topicToEdit = await _context.Topics
                .Include(r => r.Room)
                .Include(u => u.Uploader)
                .FirstOrDefaultAsync(t=>t.Id == id);

            var users = await _context.Users.ToListAsync();
            var rooms = await _context.Rooms.ToListAsync();

            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToEdit.Title,
                Description = topicToEdit.Description,
                RoomId = topicToEdit.RoomId,
                RoomName = topicToEdit.Room.Title,
                UploaderId = topicToEdit.UserId,
                UploaderName = topicToEdit.Uploader.Name,
                Users = users,
                Rooms = rooms
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var topicToShowDetails = _context.Topics
                .Include(u => u.Uploader)
                .Include(t => t.Room)
                .FirstOrDefault(t => t.Id == id);

            var uploaderFullName = topicToShowDetails.Uploader.Name + " " + topicToShowDetails.Uploader.Family;

            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToShowDetails.Title,
                Description = topicToShowDetails.Description,
                RoomName = topicToShowDetails.Room.Title,
                UploaderName = uploaderFullName,
                Id = id
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var topicToDelete = _context.Topics.Find(_topicIdToDelete);

            _context.Topics.Remove(topicToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction("Topics", "Home");
        }
    }
}