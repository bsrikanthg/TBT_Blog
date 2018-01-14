using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBT_Blog.Models;
using System.Data.Entity;
using System.IO;
using AutoMapper;
using TBT_Blog.Dtos;

namespace TBT_Blog.Controllers
{
    public class HomeController : Controller
    {
        int authorId;
        Post Post;
        BlogConnnectionDbContext _context;
        PostsViewModel postsViewModel = new PostsViewModel();


        public HomeController()
        {
            _context = new BlogConnnectionDbContext();
            authorId = _context.Authors.OrderBy(a => a.Id).FirstOrDefault().Id;
            Post = new Post() { AuthorId = authorId, CreatedOn = DateTime.Now };
        }

        [AllowAnonymous]
        public ActionResult Index(string postName = "")
        {
            if (postName.Length > 0)
            {
                postsViewModel.Posts = _context.Posts.Where(P => P.IsHidden == false).Include(m => m.Author).OrderByDescending(P => P.Id).ToList();
                postsViewModel.SelectedPost = _context.Posts.FirstOrDefault(P => P.PostName == postName);
            }
            else
            {
                postsViewModel.Posts = _context.Posts.Where(P => P.IsHidden == false).Include(m => m.Author).OrderByDescending(P => P.Id).ToList();
                postsViewModel.SelectedPost = postsViewModel.Posts.FirstOrDefault();
            }
            if (User.IsInRole(RoleNames.CanManagePosts))
            {
                return View(postsViewModel);
            }
            return View(postsViewModel);
        }


        [Authorize]
        public ActionResult Index_API()
        {
            return View("Index_api");
        }


        public ActionResult CreatePost()
        {
            ViewBag.PostType = "Create post";
            return View(Post);
        }

        public ActionResult Save(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePost", Post);
            }

            if (post.Id == 0)
            {
                post.PostContent.Replace("<table>", "<table class=\"table\">");
                _context.Posts.Add(post);
                _context.SaveChanges();
            }
            else if (post.Id > 0)
            {
                Post postInDb = _context.Posts.SingleOrDefault(P => P.Id == post.Id);

                if (postInDb == null)
                {
                    return View("CreatePost");
                }

                post.Author = _context.Authors.SingleOrDefault(A => A.Id == authorId);
                post.CreatedOn = DateTime.Now;

                Mapper.Map<Post, Post>(post, postInDb);

                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult EditPost(int Id)
        {
            ViewBag.PostType = "Edit post";
            Post post = _context.Posts.SingleOrDefault(P => P.Id == Id);
            post.PostContent = post.PostContent;
            if (Post != null)
            {
                return View("CreatePost", post);
            }

            return View("CreatePost");
        }
        public PartialViewResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    if (!Directory.Exists(Server.MapPath("~/Media/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Media/"));
                    }
                    string path = Path.Combine(Server.MapPath("~/Media/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File path on the server: " + "/Media/" + file.FileName;
                }
                catch
                {
                    ViewBag.Message = "File upload not successful";
                }
            }
            else
            {
                ViewBag.Message = "File not specified.";
            }


            Post Post = new Post() { AuthorId = authorId, CreatedOn = DateTime.Now };
            return PartialView("CreatePost", Post);
        }

        public ActionResult Serial(string letterCase)
        {
            string SN = "ASPNETMVCATM1";
            if (letterCase == "lower")
            {
                return Content(SN.ToLower(), "application/JSON");
            }
            return Content(SN);
        }


    }

}
