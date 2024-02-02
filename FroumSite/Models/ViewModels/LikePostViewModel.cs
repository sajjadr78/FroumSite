using System.Collections.Generic;

namespace FroumSite.Models.ViewModels
{
    public class LikePostViewModel
    {
        public Post Post { get; set; }
        public bool IsPostLikedByUser { get; set; } = false;
        public int LikeCount { get; set; }
    }
}
