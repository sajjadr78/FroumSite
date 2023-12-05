using System.Collections.Generic;

namespace FroumSite.Models
{
    public class TopicViewModel
    {
        public string RoomName { get; set; }
        public List<Topic> TopicsIncludedPosts { get; set; }
        public List<Post> PostsIncludedUsers { get; set; }
    }
}
