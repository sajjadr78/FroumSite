using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FroumSite.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300,ErrorMessage ="کپشن نباید بیشتر از 300 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="کپشن")]
        public string Caption { get; set; }

        [Required]
        [Display(Name ="تاریخ آپلود")]
        public DateTime UploadDate { get; set; }

        [Required]
        [Display(Name ="تعداد لایک ها")]
        public int LikeCount { get; set; }

        #region Foreign Keys

        public int UserId { get; set; }
        public int TopicId { get; set; }

        #endregion

        #region NavigationProperties

        public User User { get; set; }
        public Topic Topic { get; set; }

        public List<UserLikePost> UsersLikedThisPost { get; set; }

        #endregion


        
    }
}
