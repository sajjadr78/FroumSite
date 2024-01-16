using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FroumSite.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(50,ErrorMessage ="عنوان نباید بیشتر از 50 کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300,ErrorMessage ="توضیحات نباید بیشتر از 300 کاراکتر باشد")]
        [Required]
        public string Description { get; set; }

        [Display(Name ="تعداد لایک")]
        [Required]
        public int LikeCount { get; set; }

        [Display(Name ="تاریخ آپلود")]
        [Required]
        public DateTime UploadDate { get; set; }

        #region Foreign Keys

        public int RoomId { get; set; }

        public int UserId { get; set; }

        #endregion

        #region Navigation Properties

        
        public Room Room { get; set; }
        public User User { get; set; }
        public List<Post> Posts { get; set; }


        public List<UserLikeTopic> UsersLikedThisTopic { get; set; }
        #endregion
    }
}
