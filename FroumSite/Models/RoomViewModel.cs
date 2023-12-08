using FroumSite.Data;
using System.Collections.Generic;

namespace FroumSite.Models
{
    public class RoomViewModel
    {
        public RoomViewModel()
        {
            RoomsIncludedTopics = new List<Room>();
            TopicsIncludedUsers = new List<Topic>();
        }
        public List<Room> RoomsIncludedTopics { get; set; }
        public string SubjectName { get; set; }
        public List<Topic> TopicsIncludedUsers { get; set; }
    }
}
