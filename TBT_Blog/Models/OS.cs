using System.ComponentModel.DataAnnotations;

namespace TBT_Blog.Models
{
    public class OS
    {
        public int Id { get; set; }
        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }
    }
}