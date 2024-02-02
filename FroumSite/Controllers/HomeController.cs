using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Models.ViewModels;
using FroumSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FroumSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Subject> _subjectRepo;
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<Topic> _topicRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly int subjectId = 0;

        public HomeController(ILogger<HomeController> logger, 
            IGenericRepository<Subject> subjectRepo,
            IGenericRepository<Room> roomRepo,
            IGenericRepository<Topic> topicRepo,
            IGenericRepository<User> userRepo)
        {
            _logger = logger;
            _subjectRepo = subjectRepo;
            _roomRepo = roomRepo;
            _topicRepo = topicRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectRepo.GetAll().ToListAsync();

            return View(subjects);
        }

        public async Task<IActionResult> IsFirstUser()
        {
           var urlOfButton= Url.Action("Register", "Account", null, protocol: Request.Scheme);

            var isAnyUsersExists = await _userRepo.GetAll().AnyAsync();

            var json = new { URL_OfButton = urlOfButton , IsAnyUsersExists = isAnyUsersExists };

            return Json(json);
        }

        public async Task<IActionResult> SubjectDetails(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var roomsIncludedTopics = await _roomRepo
                 .GetAll(r => r.SubjectId == id)
                 .Include(r => r.Topics)
                 .ToListAsync();

            string subjectName = _subjectRepo.GetByIdAsync(id.Value).Result.Title;

            var topicsIncludedUsers = _topicRepo.GetAll().Include(t => t.User).ToList();

            RoomViewModel vm = new RoomViewModel
            {
                RoomsIncludedTopics = roomsIncludedTopics,
                SubjectName = subjectName,
                TopicsIncludedUsers = topicsIncludedUsers
            };

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
