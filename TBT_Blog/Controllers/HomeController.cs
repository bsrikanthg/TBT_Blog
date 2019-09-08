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
using System.Threading;

namespace TBT_Blog.Controllers
{
    public class HomeController : Controller
    {
        int authorId;
        readonly Post Post;
        BlogConnnectionDbContext _context;
        PostWithCategories postWithCategories = new PostWithCategories();


        public HomeController()
        {
            _context = new BlogConnnectionDbContext();
            authorId = _context.Authors.OrderBy(a => a.Id).FirstOrDefault().Id;
            Post = new Post() { AuthorId = authorId, CreatedOn = DateTime.Now };
            postWithCategories.SinglePost = Post;
            postWithCategories.Categories = _context.Categories.ToList();
            postWithCategories.OSs = _context.OSs.ToList();
            postWithCategories.Posts = _context.Posts.Where(P => P.IsHidden == false).Include(m => m.Author).Include(m => m.Category).Include(m => m.OS).OrderByDescending(P => P.Id).ToList();
            postWithCategories.ImageList = new List<Image>();
        }

        [AllowAnonymous]
        //        public ActionResult Index(string OS = "", string Category = "", string postName = "")
        public ActionResult Index()
        {
            if (_context.Posts.Count()==0)
            {
                ViewBag.PostType = "Create post";
                return RedirectToAction("CreatePost");
            }
            Post firstPost = new Post();

            firstPost = _context.Posts.Where(P => P.IsHidden == false).FirstOrDefault();


            postWithCategories.SinglePost = firstPost;
            if (_context.Posts.Count() > 0 && firstPost != null)
            {
                postWithCategories.Posts = _context.Posts.Where(P => P.IsHidden == false && P.Id != firstPost.Id).Include(m => m.Author).OrderByDescending(P => P.Id).ToList();
            }

            return View(postWithCategories);
        }


        [Authorize]
        public ActionResult Index_API()
        {
            return View("Index_api");
        }


        public ActionResult CreatePost()
        {
            ViewBag.PostType = "Create post";
            return View(postWithCategories);
        }

        public ActionResult Save(Post singlePost)
        {
            if (singlePost != null)
            {
                singlePost.PostName = singlePost.PostName.Replace(".", "");
                singlePost.PostContent = PostFixer.AdjustPost(singlePost.PostContent);
            }
            if (!ModelState.IsValid)
            {
                return View("CreatePost", Post);
            }

            if (singlePost.Id == 0)
            {
                singlePost.PostContent.Replace("<table>", "<table class=\"table\">");
                _context.Posts.Add(singlePost);
                _context.SaveChanges();
            }
            else if (singlePost.Id > 0)
            {
                Post postInDb = _context.Posts.SingleOrDefault(P => P.Id == singlePost.Id);

                if (postInDb == null)
                {
                    return View("CreatePost");
                }

                singlePost.CreatedOn = DateTime.Now;

                Mapper.Map<Post, Post>(singlePost, postInDb);

                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        public ActionResult DeletePost(int Id)
        {
            var post = _context.Posts.SingleOrDefault(P => P.Id == Id);
            if (post != null)
            {
                if (User.IsInRole(RoleNames.CanManagePosts))
                {
                    _context.Posts.Remove(post);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult EditPost(int Id)
        {
            ViewBag.PostType = "Edit post";
            Post post = _context.Posts.SingleOrDefault(P => P.Id == Id);
            post.PostContent = post.PostContent;

            postWithCategories.SinglePost = post;
            postWithCategories.Categories = _context.Categories.ToList();

            if (Post != null)
            {
                return View("CreatePost", postWithCategories);
            }

            return View("CreatePost");
        }

        public int Work()
        {
            Thread.Sleep(1500);
            return DateTime.Now.Second;
        }
        public string GetLongTime()
        {
            System.Threading.Thread.Sleep(5000);

            return "Time: " + DateTime.Now.ToLongDateString();
        }
        public PartialViewResult Upload()
        {
            try
            {
                string serverFolder = Server.MapPath("~/Media");
                if (!Directory.Exists(serverFolder))
                {
                    Directory.CreateDirectory(serverFolder);
                }

                if (Request.Files.Count > 0)
                {

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        file.SaveAs(serverFolder + "\\" + file.FileName);
                        ImgList.Add(new Models.Image() { ImageUrl = "/Media/" + file.FileName, Name = file.FileName });
                    }
                    ViewBag.Message = "Files uploaded successfully.";


                }
                else
                {
                    ViewBag.Message = "No files.";
                }


                return PartialView("_FileUpload", ImgList);

            }
            catch (Exception ex)
            {
                WebsiteExceptions websiteExceptions = new WebsiteExceptions();
                _context.WebsiteExceptions.Add(new WebsiteExceptions { Source = ex.Source, Message = ex.Message, InnerException = ex.InnerException.Message, TargetSite = ex.TargetSite.Name });
                _context.SaveChanges();
                ViewBag.Message = "File upload not successful, Exception: " + ex.Message + "\n Inner Exception" + ex.InnerException.Message + "\nSource: " + ex.Source;
                return PartialView("Error");
            }


        }
        List<Models.Image> ImgList = new List<Models.Image>();

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
