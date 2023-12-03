using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="لطفا عنوان را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(20,ErrorMessage ="عنوان نباید بیشتر از 20 کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(300,ErrorMessage ="توضیحات نباید بیشتر از 300 کاراکتر باشد")]
        public string Description { get; set; }

        //Navigation Properties
        public Room Room { get; set; }
        public User Uploader { get; set; }
    }
}
