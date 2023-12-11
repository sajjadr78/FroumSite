using FroumSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Areas.Admin.Models.ViewModels
{
    public class PostsViewModel
    {
        public List<Post> PostsIncludedTopic { get; set; }
        public List<Post> PostsIncludedUser { get; set; }
        [Display(Name ="عنوان تاپیک")]
        public string TopicTitle { get; set; }
        [Display(Name ="کاربر")]
        public string UploaderName { get; set; }
        [Display(Name ="کپشن")]
        public string Caption { get; set; }
        [Display(Name ="تعداد لایک ها")]
        public int LikeCount { get; set; }
        [Display(Name ="تاریخ آپلود")]
        public DateTime UploadDate { get; set; }
    }
}
