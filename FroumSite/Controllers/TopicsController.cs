using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FroumSite.Data;
using FroumSite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FroumSite.Models.ViewModels;

namespace FroumSite.Controllers
{
    public class TopicsController : Controller
    {
        private readonly FroumContext _context;
        static int roomId;
        static int topicId;

        public TopicsController(FroumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ShowPostLikes(int id)
        {
            var ulp = await _context.UserLikePosts
                .Include(u=>u.User)
                .Where(u=>u.PostId == id)
                .ToListAsync();

            return PartialView("../Topics/ShowLikeViews/_ShowPostLikes", ulp);
        }

        // GET: Topics
        public async Task<IActionResult> Index(int Id)
        {
            var topicsIncludedPosts = await _context.Topics.Where(t => t.RoomId == Id)
                .Include(t => t.Posts)
                .ToListAsync();

            var room = _context.Rooms.Find(Id);

            var postsIncludedUsers = await _context.Posts
                .Include(p => p.User)
                .ToListAsync();

            TopicViewModel vm = new TopicViewModel
            {
                TopicsIncludedPosts = topicsIncludedPosts,
                Room = room,
                PostsIncludedUsers = postsIncludedUsers,
            };

            return View(vm);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var topicIncludedPosts = await _context.Topics
                .Include(p => p.Posts)
                .FirstOrDefaultAsync(m => m.Id == id);

            var topicIncludedUsers = await _context.Topics
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            topicId = topicIncludedPosts.Id;

            var users = await _context.Users.ToListAsync();


            var userLikeTopics = await _context.UserLikeTopics
                .Where(u => u.TopicId == topicId).ToListAsync();
            var userLikePosts = await _context.UserLikePosts.ToListAsync();



            var postsCountUploaderByUser = _context.Users
                .Include(p => p.SharedPosts)
                .FirstOrDefault(u => u.Id == 12)
                .SharedPosts
                .Count;
            bool isLikedByUser = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = int.Parse(
                    User.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                        .Value);

                isLikedByUser = await _context
                                        .UserLikeTopics
                                        .AnyAsync(u => u.TopicId == id &&
                                                       u.UserId == userId);
            }

            ShowTopicAndSavePostViewModel vm = new ShowTopicAndSavePostViewModel
            {
                TopicIncludedPosts = topicIncludedPosts,
                TopicIncludedUploader = topicIncludedPosts,
                Users = users,
                PostsCountUploadedByUser = postsCountUploaderByUser,
                IsTopicLikedByUser = isLikedByUser,
                UserLikePosts = userLikePosts,
                UserLikeTopics = userLikeTopics,
                Context = _context
            };

            if (topicIncludedPosts == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [Authorize]
        public async Task<IActionResult> LikeTopic(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var userLikeTopic = await _context
                                        .UserLikeTopics
                                        .Where(u => u.TopicId == id && u.UserId == userId)
                                        .FirstOrDefaultAsync();

            var topic = _context.Topics.Find(id);

            if (userLikeTopic == null)
            {
                UserLikeTopic ult = new UserLikeTopic
                {
                    TopicId = id,
                    UserId = userId
                };
                _context.UserLikeTopics.Add(ult);
                topic.LikeCount++;
            }
            else
            {
                _context.UserLikeTopics.Remove(userLikeTopic);
                topic.LikeCount--;
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("Details", routeValues: new { id = topicId });

        }

        [Authorize]
        public async Task<IActionResult> LikePost(int id)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var userLikePost = await _context
                                        .UserLikePosts
                                        .Where(u => u.PostId == id && u.UserId == userId)
                                        .FirstOrDefaultAsync();

            var post = _context.Posts.Find(id);

            if (userLikePost == null)
            {
                UserLikePost ulp = new UserLikePost
                {
                    PostId = id,
                    UserId = userId
                };
                _context.UserLikePosts.Add(ulp);
                post.LikeCount++;
            }
            else
            {
                _context.UserLikePosts.Remove(userLikePost);
                post.LikeCount--;
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("Details", routeValues: new { id = topicId });

        }



        // GET: Topics/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            CreateTopicViewModel vm = new CreateTopicViewModel();
            roomId = id;

            return PartialView(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SavePost(ShowTopicAndSavePostViewModel vm)
        {

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);


            Post post = new Post
            {
                Caption = vm.Caption,
                LikeCount = 0,
                TopicId = topicId,
                UploadDate = DateTime.Now,
                UserId = userId
            };

            _context.Posts.Add(post);
            var result = await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { Id = topicId });
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,UserId,Title,Description")] CreateTopicViewModel vm)
        {

            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            string description = vm.Description;
            string title = vm.Title;

            Topic topic = new Topic
            {
                Description = description,
                Title = title,
                RoomId = roomId,
                UserId = userId,
                LikeCount = 0,
                UploadDate = DateTime.Now
            };

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", routeValues: new { id = roomId });
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTopicLikes()
        {
            var likes = await _context.UserLikeTopics
                .Include(u => u.User)
                .Where(u => u.TopicId == topicId).ToListAsync();

            return PartialView("../Topics/ShowLikeViews/_ShowTopicLikes", likes);
        }

        // POST: Topics/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var topic = await _context.Topics.FindAsync(id);
        //    _context.Topics.Remove(topic);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
