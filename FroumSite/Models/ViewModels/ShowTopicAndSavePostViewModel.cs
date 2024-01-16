using FroumSite.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models.ViewModels
{
    public class ShowTopicAndSavePostViewModel
    {
        public Topic TopicIncludedUploader { get; set; }
        [MaxLength(300, ErrorMessage = "کپشن نباید بیشتر از 300 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا نظر خود را وارد کنید")]
        [Display(Name = "نظر شما")]
        public string Caption { get; set; }
        public int PostsCountUploadedByUser { get; set; }
        public bool IsTopicLikedByUser { get; set; }
        public int RoomId { get; set; }
        public List<Post> PostsOfCurrentTopic { get; set; }
        public List<UserLikeTopic> UserLikeTopics { get; set; }
        public List<UserLikePost> UserLikePosts { get; set; }
    }
}
