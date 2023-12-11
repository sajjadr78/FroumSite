using FroumSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Areas.Admin.Models.ViewModels
{
    public class RoomsViewModel
    {
        [Display(Name ="نام")]
        public string RoomName { get; set; }
        [Display(Name ="موضوع")]
        public string SubjectName { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
