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
    public class PostsController : Controller
    {
        private readonly FroumContext _context;
        private static int _postIdToEdit = 0;
        private static int _postIdToDelete = 0;
        public PostsController(FroumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var users = await _context.Users.ToListAsync();
            var topics = await _context.Topics.ToListAsync();
            PostsViewModel vm = new PostsViewModel
            {
                Users = users,
                Topics = topics
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(PostsViewModel vm)
        {
            if (_postIdToEdit == 0)
            {
                Post post = new Post
                {
                    Caption = vm.Caption,
                    LikeCount = 0,
                    TopicId = vm.TopicId,
                    UserId = vm.UserId,
                    UploadDate = System.DateTime.Now
                };

                _context.Posts.Add(post);
            }
            else
            {
                var postToEdit = await _context.Posts
                    .FirstOrDefaultAsync(p => p.Id == _postIdToEdit);

                if (postToEdit != null)
                {
                    postToEdit.UserId = vm.UserId;
                    postToEdit.TopicId = vm.TopicId;
                    postToEdit.Caption = vm.Caption;
                    postToEdit.LikeCount = vm.LikeCount;
                    postToEdit.UploadDate = vm.UploadDate;
                }
            }


            await _context.SaveChangesAsync();

            _postIdToEdit = 0;

            return RedirectToAction("Posts", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            _postIdToDelete = id;

            var postToDelete = await _context.Posts
                .Include(t => t.Topic)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            

            PostsViewModel vm = new PostsViewModel
            {
                Caption = postToDelete.Caption,
                LikeCount = postToDelete.LikeCount,
                TopicId = postToDelete.TopicId,
                UploadDate = postToDelete.UploadDate,
                UserId = postToDelete.UserId,
                TopicTitle = postToDelete.Topic.Title,
                UploaderName = postToDelete.User.Name
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            _postIdToEdit = id;

            var postToEdit = _context.Posts.Find(id);
            var users = await _context.Users.ToListAsync();
            var topics = await _context.Topics.ToListAsync();

            PostsViewModel vm = new PostsViewModel
            {
                Caption = postToEdit.Caption,
                LikeCount = postToEdit.LikeCount,
                TopicId = postToEdit.TopicId,
                UploadDate = postToEdit.UploadDate,
                UserId = postToEdit.UserId,
                Users = users,
                Topics = topics
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var postToShowDetails = _context.Posts
                .Include(u => u.User)
                .Include(t => t.Topic)
                .FirstOrDefault(o => o.Id == id);

            var uploaderFullName = postToShowDetails.User.Name + " " + postToShowDetails.User.Family;

            PostsViewModel vm = new PostsViewModel
            {
                Caption = postToShowDetails.Caption,
                LikeCount = postToShowDetails.LikeCount,
                TopicTitle = postToShowDetails.Topic.Title,
                UploaderName = uploaderFullName,
                Id = id,
                UploadDate = postToShowDetails.UploadDate
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var postToDelete = _context.Posts.Find(_postIdToDelete);

            _context.Posts.Remove(postToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction("Posts", "Home");
        }
    }
}
