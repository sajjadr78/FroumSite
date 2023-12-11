using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FroumSite.Models.ViewModels
{
    public class ShowTopicAndSavePostViewModel
    {
        public Topic TopicIncludedPosts { get; set; }
        public Topic TopicIncludedUploader { get; set; }
        [MaxLength(300, ErrorMessage = "کپشن نباید بیشتر از 300 کاراکتر باشد")]
        [Required(ErrorMessage = "کپشن اجباری است")]
        [Display(Name = "کپشن")]
        public string Caption { get; set; }
        public List<User> Users { get; set; }

    }
}
