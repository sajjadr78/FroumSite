using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Models.ViewModels;

namespace FroumSite.Controllers
{
    public class RoomsController : Controller
    {
        private readonly FroumContext _context;

        public RoomsController(FroumContext context)
        {
            _context = context;
        }

        // GET: Rooms
        [Route("Rooms/{Id}")]
        public async Task<IActionResult> Index(int Id)
        {
            var roomsIncludedTopics = await _context.Rooms
                .Where(r => r.SubjectId == Id)
                .Include(r => r.Topics)
                .ToListAsync();

            string subjectName = _context.Subjects.Find(Id).Title;

            var topicsIncludedUsers = _context.Topics.Include(t => t.User).ToList();

            RoomViewModel vm = new RoomViewModel
            {
                RoomsIncludedTopics = roomsIncludedTopics,
                SubjectName = subjectName,
                TopicsIncludedUsers = topicsIncludedUsers,
                RoomId = Id
            };

            return View( vm);
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> RoomDetails(int id)
        {
            var topicsIncludedPosts = await _context.Topics.Where(t => t.RoomId == id)
                .Include(t => t.Posts)
                .ToListAsync();

            var room = _context.Rooms.Find(id);

            var postsIncludedUsers = await _context.Posts
                .Include(p => p.User)
                .ToListAsync();

            TopicViewModel vm = new TopicViewModel
            {
                TopicsIncludedPosts = topicsIncludedPosts,
                Room = room,
                PostsIncludedUsers = postsIncludedUsers
            };

            return PartialView(vm);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
