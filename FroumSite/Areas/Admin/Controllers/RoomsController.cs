using Microsoft.AspNetCore.Mvc;

namespace FroumSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        public IActionResult Create()
        {
            return View();
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
