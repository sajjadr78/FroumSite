using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Models.ViewModels;
using FroumSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly int subjectId = 0;

        public HomeController(ILogger<HomeController> logger, 
            IGenericRepository<Subject> subjectRepo,
            IGenericRepository<Room> roomRepo,
            IGenericRepository<Topic> topicRepo)
        {
            _logger = logger;
            _subjectRepo = subjectRepo;
            _roomRepo = roomRepo;
            _topicRepo = topicRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _subjectRepo.GetAll().ToListAsync());
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
