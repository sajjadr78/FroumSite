using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        #region Foreign Keys

        public int UserId { get; set; }
        public int TopicId { get; set; }

        #endregion

        #region NavigationProperties

        [ForeignKey("UserId")]
        public User Uploader { get; set; }
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        #endregion
    }
}
