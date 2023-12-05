using FroumSite.Data;
using System.Collections.Generic;

namespace FroumSite.Models
{
    public class RoomViewModel
    {
        public RoomViewModel()
        {

            Topics = new List<Topic>();
        }
        public List<Room> Rooms { get; set; }
        public string SubjectName { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
