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
using FroumSite.Areas.Admin.Models.ViewModels;
using System.Threading;
using FroumSite.Utilities;
using FroumSite.Repositories;

namespace FroumSite.Controllers
{
    public class TopicsController : Controller
    {
        private readonly FroumContext _context;


        private readonly GenericRepository<Topic> _topicRepo;
        private readonly GenericRepository<Room> _roomRepo;
        private readonly GenericRepository<Post> _postRepo;
        private readonly GenericRepository<User> _userRepo;
        private readonly GenericRepository<UserLikePost> _userLikePostRepo;
        private readonly GenericRepository<UserLikeTopic> _userLikeTopicRepo;
        private static int _roomId;
        private static int _topicId;
        private static int _topicIdToDelete;
        private static int _topicIdToEdit;
        private static int _postIdToDelete;
        private static int _postIdToEdit;

        public TopicsController(GenericRepository<Topic> topicRepo,
                                GenericRepository<Room> roomRepo,
                                GenericRepository<UserLikePost> userLikePostRepo,
                                GenericRepository<UserLikeTopic> userLikeTopicRepo,
                                GenericRepository<Post> postRepo,
                                GenericRepository<User> userRepo,
                                FroumContext context)
        {
            _topicRepo = topicRepo;
            _roomRepo = roomRepo;
            _postRepo = postRepo;
            _userRepo = userRepo;
            _userLikePostRepo = userLikePostRepo;
            _userLikeTopicRepo = userLikeTopicRepo;
            _context = context;
        }

        public async Task<IActionResult> ShowPostLikes(int id)
        {
            var ulp = await _userLikePostRepo
                .GetAll(u => u.PostId == id)
                .Include(u => u.User)
                .ToListAsync();

            return View("../Topics/ShowLikeViews/_ShowPostLikes", ulp);
        }

        // GET: Topics
        public async Task<IActionResult> Index(int Id)
        {
            TopicViewModel vm = await InitialViewModel(Id);

            return View(vm);
        }

        private async Task<TopicViewModel> InitialViewModel(int roomId)
        {
            var topicsIncludedPosts = await _topicRepo
                            .GetAll(t => t.RoomId == roomId)
                            .Include(t => t.Posts)
                            .ToListAsync();

            var room = await _roomRepo.GetByIdAsync(roomId);

            var postsIncludedUsers = await _postRepo
                .GetAll()
                .Include(p => p.User)
                .ToListAsync();

            TopicViewModel vm = new TopicViewModel
            {
                TopicsIncludedPosts = topicsIncludedPosts,
                Room = room,
                PostsIncludedUsers = postsIncludedUsers
            };
            return vm;
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int id)
        {

            _topicId = id;



            var topicIncludedUsers = await _topicRepo
                .GetAll()
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == _topicId);




            var postsOfCurrentTopic = await _postRepo
                .GetAll(p => p.TopicId == _topicId)
                .Include(u => u.User)
                .ToListAsync();

            var userLikeTopics = await _userLikeTopicRepo
                .GetAll(u => u.TopicId == _topicId)
                .ToListAsync();

            var userLikePosts = await _userLikePostRepo
                .GetAll(u => u.Post.TopicId == _topicId)
                .Include(s => s.Post)
                .ToListAsync();

            var currentUserId = int.Parse(User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                .Value);

            var postsCountUploadedByUser = _userRepo.GetAll()
                .Include(p => p.SharedPosts)
                .FirstOrDefault(u => u.Id == currentUserId)
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
                TopicIncludedUploader = topicIncludedUsers,
                PostsOfCurrentTopic = postsOfCurrentTopic,
                PostsCountUploadedByUser = postsCountUploadedByUser,
                IsTopicLikedByUser = isLikedByUser,
                UserLikePosts = userLikePosts,
                UserLikeTopics = userLikeTopics
            };

            if (postsOfCurrentTopic == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        public async Task<IActionResult> EditPostByUser(int id)
        {
            _postIdToEdit = id;
            var post = await _postRepo.GetByIdAsync(_postIdToEdit);


            return View("_EditPostByUser", post);
        }

        [Authorize]
        public async Task<IActionResult> LikeTopic()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var userLikeTopic = await _context
                                        .UserLikeTopics
                                        .Where(u => u.TopicId == _topicId && u.UserId == userId)
                                        .FirstOrDefaultAsync();

            var topic = _context.Topics.Find(_topicId);
            LikeViewModel likeViewModel = new LikeViewModel();
            if (userLikeTopic == null)
            {
                UserLikeTopic ult = new UserLikeTopic
                {
                    TopicId = _topicId,
                    UserId = userId
                };
                _context.UserLikeTopics.Add(ult);
                topic.LikeCount++;
                await _context.SaveChangesAsync();

                likeViewModel.LikeCount = topic.LikeCount;
                likeViewModel.IsLiked = true;

            }
            else
            {
                _context.UserLikeTopics.Remove(userLikeTopic);
                topic.LikeCount--;
                await _context.SaveChangesAsync();

                likeViewModel.LikeCount = topic.LikeCount;
                likeViewModel.IsLiked = false;

            }
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_TopicLikeButton", likeViewModel) });




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

            var userLikePosts = await _context.UserLikePosts.ToListAsync();

            post = _context.Posts.Find(id);

            LikePostViewModel likePostViewModel = new LikePostViewModel
            {
                id = id,
                UserLikePosts = userLikePosts,
                postLikeCount = post.LikeCount
            };

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_LikePostButton", likePostViewModel) };

            return Json(json);

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
                TopicId = _topicId,
                UploadDate = DateTime.Now,
                UserId = userId
            };

            _context.Posts.Add(post);
            var result = await _context.SaveChangesAsync();



            var postsOfCurrentTopic = await _postRepo
                .GetAll(p => p.TopicId == _topicId)
                .Include(u => u.User)
                .ToListAsync();

            

            vm.PostsOfCurrentTopic = postsOfCurrentTopic;
            vm.UserLikePosts = _context.UserLikePosts
                .Include(s => s.Post)
                .Where(u => u.Post.TopicId == _topicId).ToList();


            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllPosts", vm) });

        }

        [HttpPost]
        public async Task<IActionResult> SaveEditedPost(int id, [Bind("Id,Caption,UploadDate,LikeCount,UserId,TopicId")] Post editedPost)
        {
            var postToEdit = await _postRepo.GetByIdAsync(id);

            postToEdit.Caption = editedPost.Caption;
            await _postRepo.SaveChangesAsync();



            var postsOfCurrentTopic = await _postRepo
                .GetAll(p => p.TopicId == _topicId)
                .Include(u => u.User)
                .ToListAsync();

            var userLikePosts = await _userLikePostRepo
                .GetAll(u => u.Post.TopicId == _topicId)
                .Include(s => s.Post)
                .ToListAsync();

            ShowTopicAndSavePostViewModel vm = new ShowTopicAndSavePostViewModel
            {
                UserLikePosts = userLikePosts,
                PostsOfCurrentTopic = postsOfCurrentTopic
            };
            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllPosts", vm) };
            return Json(json);
        }

        // GET: Topics/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            CreateTopicViewModel vm = new CreateTopicViewModel();
            _roomId = id;

            return View(vm);
        }


        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,UserId,Title,Description")] CreateTopicViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    string description = vm.Description;
                    string title = vm.Title;

                    Topic topic = new Topic
                    {
                        Description = description,
                        Title = title,
                        RoomId = _roomId,
                        UserId = userId,
                        LikeCount = 0,
                        UploadDate = DateTime.Now
                    };

                    _context.Topics.Add(topic);
                    await _context.SaveChangesAsync();

                    TopicViewModel initailizedViewModel = await InitialViewModel(_roomId);


                    var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllTopicsOfRoom", initailizedViewModel) };
                    return Json(json);
                }
                catch (Exception)
                {
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", vm) });

                }


            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", vm) });
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
        [Authorize]
        public async Task<IActionResult> DeleteTopicByUser(int id)
        {
            _topicIdToDelete = id;

            var topicToDelete = await _context.Topics
                .Include(t => t.Room)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);



            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToDelete.Title,
                Description = topicToDelete.Description,
                RoomName = topicToDelete.Room.Title,
                UploaderName = topicToDelete.User.Name
            };

            return View("_DeleteTopicByUser", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed()
        {
            TopicViewModel vm = new TopicViewModel();
            try
            {
                var topicToDelete = _context.Topics.Find(_topicIdToDelete);

                _context.Topics.Remove(topicToDelete);

                await _context.SaveChangesAsync();

                vm = await InitialViewModel(_roomId);

                var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllTopicsOfRoom", vm) };

                return Json(json);
            }
            catch
            {
                var json = new { isValid = false, html = Helper.RenderRazorViewToString(this, "_DeleteTopicByUser", vm) };

                return Json(json);
            }

        }

        [Authorize]
        public async Task<IActionResult> EditTopicByUser(int id)
        {
            _topicIdToEdit = id;

            var topicToEdit = await _context.Topics
                .Include(r => r.Room)
                .Include(u => u.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            var users = await _context.Users.ToListAsync();
            var rooms = await _context.Rooms.ToListAsync();

            TopicsViewModel vm = new TopicsViewModel
            {
                Title = topicToEdit.Title,
                Description = topicToEdit.Description,
                RoomId = topicToEdit.RoomId,
                RoomName = topicToEdit.Room.Title,
                UploaderId = topicToEdit.UserId,
                UploaderName = topicToEdit.User.Name,
                Users = users,
                Rooms = rooms
            };

            return PartialView(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditConfirmed(TopicsViewModel vm)
        {
            var topicToEdit = await _context.Topics
                .FirstOrDefaultAsync(p => p.Id == _topicIdToEdit);

            if (topicToEdit != null)
            {
                topicToEdit.RoomId = vm.RoomId;
                topicToEdit.Description = vm.Description;
                topicToEdit.Title = vm.Title;
            }

            await _context.SaveChangesAsync();

            _topicIdToEdit = 0;

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> DeletePostByUser(int id)
        {
            _postIdToDelete = id;

            var postToDelete = await _context.Posts
                .Include(t => t.Topic)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);



            return View("_DeletePostByUser", postToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeletePost()
        {
            var postToDelete = await _context.Posts
                .FirstOrDefaultAsync(p => p.Id == _postIdToDelete);

            _context.Posts.Remove(postToDelete);
            await _context.SaveChangesAsync();

            var postsOfCurrentTopic = await _postRepo
                .GetAll(p => p.TopicId == _topicId)
                .Include(u => u.User)
                .ToListAsync();


            var userLikePosts = await _userLikePostRepo
                .GetAll(u => u.Post.TopicId == _topicId)
                .Include(s => s.Post)
                .ToListAsync();

            ShowTopicAndSavePostViewModel vm = new ShowTopicAndSavePostViewModel
            {
                UserLikePosts = userLikePosts,
                PostsOfCurrentTopic = postsOfCurrentTopic
            };

            var json = new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllPosts", vm) };
            return Json(json);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTopicLikes()
        {
            var likes = await _context.UserLikeTopics
                .Include(u => u.User)
                .Where(u => u.TopicId == _topicId).ToListAsync();

            return View("../Topics/ShowLikeViews/_ShowTopicLikes", likes);
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
