using System.ComponentModel.DataAnnotations;

namespace FroumSite.Data.Abstractions
{
    public class TableData
    {
        [Key]
        public int Id { get; set; }
    }
}
