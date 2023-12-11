using FroumSite.Areas.Admin.Models.ViewModels;
using FroumSite.Data;
using FroumSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroumSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly FroumContext _context;

        public HomeController(FroumContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Rooms()
        {
            var rooms = await _context.Rooms
                .Include(r=>r.Subject)
                .ToListAsync();

            RoomsViewModel vm = new RoomsViewModel
            {
                Rooms = rooms
            };

            return View(vm);
        }

        //[Route("/Admin/Users")]
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Posts()
        {
            var postsIncludedTopic = await _context.Posts
                .Include(p=> p.Topic )
                .ToListAsync();

            var postsIncludedUser = await _context.Posts
                .Include(p => p.Uploader)
                .ToListAsync();

            PostsViewModel vm = new PostsViewModel
            {
                PostsIncludedTopic = postsIncludedTopic,
                PostsIncludedUser = postsIncludedTopic
            };

            return View(vm);
        }

        public async Task<IActionResult> Topics()
        {
            var topicsIncludedRooms = await _context.Topics
                .Include(t=>t.Room)
                .ToListAsync();

            var topicsIncludedUsers = await _context.Topics
                .Include(t => t.Uploader)
                .ToListAsync();

            TopicsViewModel vm = new TopicsViewModel
            {
                TopicsIncludedRooms = topicsIncludedRooms,
                TopicsIncludedUsers = topicsIncludedUsers
            };
            return View(vm);
        }

        public async Task<IActionResult> Subjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return View(subjects);
        }


    }
}
