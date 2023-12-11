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

            return RedirectToAction("Subjects", "Home");
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
            var subjectToDelete = _context.Subjects.Find(_subjectIdToDelete);

            _context.Subjects.Remove(subjectToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction("Subjects", "Home");
        }
    }
}
