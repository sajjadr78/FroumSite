using FroumSite.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Areas.Admin.Models.ViewModels
{
    public class TopicsViewModel
    {
        public List<Topic> TopicsIncludedRooms { get; set; }
        public List<Topic> TopicsIncludedUsers { get; set; }

        public int Id { get; set; }

        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }

        public int UploaderId { get; set; }
        public int RoomId { get; set; }

        [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(50, ErrorMessage = "عنوان نباید بیشتر از 50 کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300, ErrorMessage = "توضیحات نباید بیشتر از 300 کاراکتر باشد")]
        public string Description { get; set; }

        [Display(Name = "نام تالار")]
        public string RoomName { get; set; }

        [Display(Name = "کاربر")]
        public string UploaderName { get; set; }
    }
}
