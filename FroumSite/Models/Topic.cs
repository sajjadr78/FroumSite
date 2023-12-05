using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FroumSite.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="لطفا عنوان را وارد کنید")]
        [Display(Name = "عنوان")]
        [MaxLength(50,ErrorMessage ="عنوان نباید بیشتر از 50 کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300,ErrorMessage ="توضیحات نباید بیشتر از 300 کاراکتر باشد")]
        public string Description { get; set; }


        #region Foreign Keys

        [Required]
        public int RoomId { get; set; }

        //this line generates error so i added some codes on froumcontext.cs line 27
        [Required]
        public int UserId { get; set; }


        #endregion

        #region Navigation Properties

        //[ForeignKey("RoomId")]
        public Room Room { get; set; }
        //[Display(Name ="توسط")]
        //[ForeignKey("UserId")]
        public User Uploader { get; set; }


        public List<Post> Posts { get; set; }
        #endregion
    }
}
