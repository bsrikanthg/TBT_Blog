using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public Post SelectedPost { get; set; }
    }
}