using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBT_Blog.Models;

namespace TBT_Blog.Controllers
{
    public class PostsLikedByAuthorController : Controller
    {

        BlogConnnectionDbContext _context;

        public PostsLikedByAuthorController()
        {
            _context = new BlogConnnectionDbContext();
        }

        // GET: PostsLikedByAuthor
        public ActionResult PostLikedByAuthor()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(_context.Posts.ToList());
        }

        [HttpPost]
        public ActionResult Index(string SearchPost)
        {
            List<Post> posts;
            if (string.IsNullOrEmpty(SearchPost))
            {
                posts = _context.Posts.ToList();
            }
            else
            {
                posts = _context.Posts.Where(A => A.PostName.Contains(SearchPost)).ToList();
            }
            return View(posts);
        }

        [HttpPost]
        public void SetPostsLiked(string author, string[] PostNames)
        {

        }

        public JsonResult GetAuthors(string term)
        {
            List<string> posts;
            posts = _context.Authors.Where(A => A.Name.Contains(term)).Select(A => A.Name).ToList();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPosts(string term)
        {
            List<string> posts;
            posts = _context.Posts.Where(P => P.PostName.Contains(term)).Select(P => P.PostName).ToList();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }
    }
}