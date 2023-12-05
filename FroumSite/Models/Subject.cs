using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class Subject
    {
        public Subject()
        {
            Rooms = new List<Room>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [MaxLength(20, ErrorMessage = "نام نباید بیشتر از 20 کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        public string Title { get; set; }


        #region Navigation Properties

        public List<Room> Rooms { get; set; }

        #endregion
    }
}
