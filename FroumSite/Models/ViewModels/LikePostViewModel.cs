using System.Collections.Generic;

namespace FroumSite.Models.ViewModels
{
    public class LikePostViewModel
    {
        public int id { get; set; }
        public List<UserLikePost> UserLikePosts { get; set; }
        public int postLikeCount { get; set; }
    }
}
