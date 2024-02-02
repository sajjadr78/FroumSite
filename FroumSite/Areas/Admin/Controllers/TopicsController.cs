using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
                    Title = vm.Title,
                    UploadDate = System.DateTime.Now
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

            var topicsIncludedRooms = await _context.Topics
                .Include(t => t.Room)
                .ToListAsync();

            var topicsIncludedUsers = await _context.Topics
                .Include(t => t.User)
                .ToListAsync();

            TopicsViewModel topicsViewModel = new TopicsViewModel
            {
                TopicsIncludedRooms = topicsIncludedRooms,
                TopicsIncludedUsers = topicsIncludedUsers
            };

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_TopicsPartial", topicsViewModel) };

            return Json(json);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _topicIdToDelete = id;

            var topicToDelete = await _context.Topics
                .Include(t => t.Room)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);



            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToDelete.Title,
                Description = topicToDelete.Description,
                RoomName = topicToDelete.Room.Title,
                UploaderName = topicToDelete.User.Name,
                Id = id
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            _topicIdToEdit = id;

            var topicToEdit = await _context.Topics
                .Include(r => r.Room)
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            var users = await _context.Users.ToListAsync();
            var rooms = await _context.Rooms.ToListAsync();

            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToEdit.Title,
                Description = topicToEdit.Description,
                RoomId = topicToEdit.RoomId,
                RoomName = topicToEdit.Room.Title,
                UploaderId = topicToEdit.UserId,
                UploaderName = topicToEdit.User.Name,
                Users = users,
                Rooms = rooms
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var topicToShowDetails = _context.Topics
                .Include(u => u.User)
                .Include(t => t.Room)
                .FirstOrDefault(t => t.Id == id);

            var uploaderFullName = topicToShowDetails.User.Name + " " + topicToShowDetails.User.Family;

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
            try
            {
                var topicToDelete = _context.Topics
                    .Include(p=>p.Posts)
                    .FirstOrDefault(t=>t.Id == _topicIdToDelete);

                var hasAnyPosts = topicToDelete.Posts.Any();

                if (hasAnyPosts)
                {
                    var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                    "این تاپیک دارای پست هایی می باشد بنابراین نمی توان آنرا حذف نمود" +
                    "</h3>";
                    var jsonResult = new { isValid = false, error = errorTag };

                    return Json(jsonResult);
                }

                _context.Topics.Remove(topicToDelete);

                await _context.SaveChangesAsync();

                var json = new { isValid = true };

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