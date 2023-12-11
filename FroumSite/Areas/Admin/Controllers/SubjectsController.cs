using FroumSite.Data;
using FroumSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FroumSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectsController : Controller
    {
        private readonly FroumContext _context;

        public SubjectsController(FroumContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View(new Subject());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return RedirectToAction("Subjects","Home");
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
