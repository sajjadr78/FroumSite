using FroumSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Areas.Admin.Models.ViewModels
{
    public class PostsViewModel
    {

        public PostsViewModel()
        {
            PostsIncludedTopic = new List<Post>();
            PostsIncludedUser = new List<Post>();
            Users = new List<User>();
            Topics = new List<Topic>();
        }

        public int Id { get; set; }

        public int TopicId { get; set; }
        public int UserId { get; set; }

        public List<Post> PostsIncludedTopic { get; set; }
        public List<Post> PostsIncludedUser { get; set; }

        [Display(Name = "کپشن")]
        [Required]
        public string Caption { get; set; }
        [Display(Name = "تعداد لایک ها")]
        public int LikeCount { get; set; }
        [Display(Name = "تاریخ آپلود")]
        public DateTime UploadDate { get; set; }
        [Display(Name = "کاربر")]
        public string UploaderName { get; set; }
        public List<User> Users { get; set; }

        [Display(Name = "عنوان تاپیک")]
        public string TopicTitle { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
