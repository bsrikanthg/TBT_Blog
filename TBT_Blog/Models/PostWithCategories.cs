using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models
{
    public class PostWithCategories
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<OS> OSs { get; set; }
        public Post SinglePost { get; set; }
        public List<Image> ImageList { get; set; }
        public bool ImageEdited { get; set; }
    }
}