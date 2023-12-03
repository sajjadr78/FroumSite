using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models
{
    public class Room
    {
        public Room()
        {
            Topics = new List<Topic>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name ="عنوان تالار")]
        [MaxLength(20,ErrorMessage ="عنوان تالار نباید بیشتر از 20 کاراکتر باشد")]
        [Required(ErrorMessage ="لطفا عنوان تالار را وارد کنید")]
        public string Title { get; set; }


        //Navigation Properties
        public Subject Subject { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
