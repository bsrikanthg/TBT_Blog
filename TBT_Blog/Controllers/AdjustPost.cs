using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TBT_Blog.Models;

namespace TBT_Blog.Controllers
{
    public class PostFixer
    {
        public static string AdjustPost(string postContent)
        {

            if (postContent.Contains("../../../"))
            {
                postContent = postContent.Replace("../../../", "../").Replace("../", "../../../");
                return postContent;
            }
            else if (postContent.Contains("../"))
            {
                postContent = postContent.Replace("../", "../../../");
                return postContent;
            }
            return postContent;

        }
    }
}