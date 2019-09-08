using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBT_Blog.Models.ViewModels
{
    public class BlogPostData
    {
        public Post Post { get; set; }
        public List<Post> SimilarPosts { get; set; }
        public List<Category> AllCategoryList { get; set; }
        public List<OS> AllOssList { get; set; }
    }
}