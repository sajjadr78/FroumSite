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
    public class SubjectsController : Controller
    {
        private readonly FroumContext _context;
        private static int _subjectIdToEdit = 0;
        private static int _subjectIdToDelete = 0;
        public SubjectsController(FroumContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            Subject subject = new Subject();

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Subject subject)
        {
            if (_subjectIdToEdit == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var subjectToEdit = await _context.Subjects
                    .FirstOrDefaultAsync(p => p.Id == _subjectIdToEdit);

                if (subjectToEdit != null)
                {
                    subjectToEdit.Title = subject.Title;
                }
            }


            await _context.SaveChangesAsync();

            _subjectIdToEdit = 0;

            var subjects = await _context.Subjects.ToListAsync();

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_SubjectsPartial", subjects) };

            return Json(json);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _subjectIdToDelete = id;

            var subjectToDelete = await _context.Subjects
                .FirstOrDefaultAsync(p => p.Id == id);





            return View(subjectToDelete);
        }

        public IActionResult Edit(int id)
        {
            _subjectIdToEdit = id;

            var subjectToEdit = _context.Subjects.Find(id);


            return View(subjectToEdit);
        }

        public IActionResult Details(int id)
        {
            var subjectToShowDetails = _context.Subjects
                .FirstOrDefault(s => s.Id == id);



            return View(subjectToShowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            try
            {
                var subjectToDelete = _context.Subjects
                .Include(r => r.Rooms)
                .FirstOrDefault(s => s.Id == _subjectIdToDelete);

                var hasAnyRooms = subjectToDelete.Rooms.Any();

                if (hasAnyRooms)
                {
                    var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                        "این موضوع دارای تالار هایی می باشد بنابراین نمی توان آنرا حذف نمود" +
                        "</h3>";
                    var jsonResult = new { isValid = false, error = errorTag };

                    return Json(jsonResult);
                }

                _context.Subjects.Remove(subjectToDelete);

                await _context.SaveChangesAsync();

                var json = new { isValid = true };

                return Json(json);
            }
            catch
            {
                var errorTag = "<h3 class=\"bg-danger text-white p-2 mb-2 mt-2 col-12\">" +
                        "خطا!" +
                        "</h3>";
                var jsonResult = new { isValid = false, error = errorTag };

                return Json(jsonResult);
            }

            
        }
    }
}
