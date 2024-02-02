using System.Collections.Generic;

namespace FroumSite.Models.ViewModels
{
    public class SubjectViewModel
    {
        public List<Subject> Subjects { get; set; }
        public bool IsAnyUsersExists { get; set; }
    }
}
