using System.Collections.Generic;

namespace FroumSite.Models.ViewModels
{
    public class TopicViewModel
    {
        public Room Room { get; set; }
        public List<Topic> TopicsIncludedPosts { get; set; }
        public List<Post> PostsIncludedUsers { get; set; }
    }
}
