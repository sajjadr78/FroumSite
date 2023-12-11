using FroumSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Areas.Admin.Models.ViewModels
{
    public class RoomsViewModel
    {
        public int Id { get; set; }

        [Display(Name ="نام")]
        public string RoomTitle { get; set; }
        [Display(Name ="عنوان موضوع")]
        public string SubjectTitle { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Subject> Subjects { get; set; }
        public int SubjectId { get; set; }
    }
}
