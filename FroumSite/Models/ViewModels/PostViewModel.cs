using System.Collections.Generic;

namespace FroumSite.Models.ViewModels
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; }
        public string PostCaption { get; set; }
        public Post Post { get; set; }
        public List<UserLikePost> UserLikePosts { get; set; }
        
    }
}
