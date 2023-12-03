using System;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300,ErrorMessage ="کپشن نباید بیشتر از 300 کاراکتر باشد")]
        [Required(ErrorMessage ="کپشن اجباری است")]
        [Display(Name ="کپشن")]
        public string Caption { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public int LikeCount { get; set; }

        //Navigation Properties
        public User Uploader { get; set; }
        public Topic Topic { get; set; }
    }
}
