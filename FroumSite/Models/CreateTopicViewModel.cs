using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class CreateTopicViewModel
    {
        [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(50, ErrorMessage = "عنوان نباید بیشتر از 50 کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300, ErrorMessage = "توضیحات نباید بیشتر از 300 کاراکتر باشد")]
        public string Description { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
