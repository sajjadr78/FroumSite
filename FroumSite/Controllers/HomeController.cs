using FroumSite.Data;
using FroumSite.Models.ViewModels;
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
        private readonly FroumContext _context;
        private readonly int subjectId = 0;

        public HomeController(ILogger<HomeController> logger, FroumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        public async Task<IActionResult> SubjectDetails(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var roomsIncludedTopics = await _context.Rooms
                 .Where(r => r.SubjectId == id)
                 .Include(r => r.Topics)
                 .ToListAsync();

            string subjectName = _context.Subjects.Find(id).Title;

            var topicsIncludedUsers = _context.Topics.Include(t => t.User).ToList();

            RoomViewModel vm = new RoomViewModel
            {
                RoomsIncludedTopics = roomsIncludedTopics,
                SubjectName = subjectName,
                TopicsIncludedUsers = topicsIncludedUsers
            };

            return PartialView(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
