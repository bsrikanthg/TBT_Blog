using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TBT_Blog.Models;
using TBT_Blog.Models.ViewModels;
using System.IO;

namespace TBT_Blog.Controllers
{
    public class PostController : Controller
    {

        BlogConnnectionDbContext _context;
        BlogPostData blogPostData;

        public PostController()
        {
            _context = new BlogConnnectionDbContext();
            blogPostData = new BlogPostData();
        }

        // GET: Post
        [AllowAnonymous]
        public ActionResult Index(string OperatingSystem = "", string Category = "", string postName = "")
        {
            IQueryable<Post> posts = _context.Posts.Include(P => P.OS).Include(P => P.Category).Include(P => P.Author).Where(P => P.IsHidden == false);

            string _viewName = string.Empty;

            OS os = new Models.OS();
            os = _context.OSs.SingleOrDefault(O => O.OperatingSystem == OperatingSystem);

            Category c = new Models.Category();
            c = _context.Categories.SingleOrDefault(C => C.CategoryName == Category);

            if (os == null)
            {
                //No OS, return to home page
                return RedirectToAction("Index", "Home");
            }

            if (c == null)
            {
                //Shows all post under OS
                blogPostData.SimilarPosts = posts.Where(P => P.OS.OperatingSystem == OperatingSystem && P.CategoryId > 0).ToList();
                _viewName = "OSPosts";
            }

            else if (postName.Length > 0)
            {
                //Category and postName given, show relevent data with a post.
                blogPostData.Post = posts.Where(P => P.OS.OperatingSystem == OperatingSystem && P.Category.CategoryName == Category && P.PostName == postName).FirstOrDefault();

                blogPostData.SimilarPosts = posts.Where(P => P.OS.OperatingSystem == OperatingSystem && P.Category.CategoryName == Category && P.PostName != postName).ToList();
                if (blogPostData.Post != null)
                {
                    _viewName = "SinglePost";
                }
                else
                {
                    _viewName = "CategoryPosts";
                }
            }
            else
            {
                //All posts in a category.
                blogPostData.SimilarPosts = posts.Where(P => P.OS.OperatingSystem == OperatingSystem && P.Category.CategoryName == Category).ToList();
                if (blogPostData.SimilarPosts.Count == 0)
                {
                    _context.WebsiteExceptions.Add(new WebsiteExceptions { Message = "No posts for the category: " + Category + "." });
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                _viewName = "CategoryPosts";
            }


            blogPostData.AllCategoryList = _context.Categories.ToList();
            //Todo:
            blogPostData.AllOssList = _context.OSs.ToList();

            return View(_viewName, blogPostData);
        }


        public ActionResult ImagesInFolder(string folder)
        {
            List<Image> imageList = new List<Image>();
            if (!Directory.Exists(Server.MapPath("~/" + folder)))
            {
                return View("ImagesInFolder", imageList);
            }


            if (folder.Length > 0)
            {
                string[] imgeExt = { ".jpg", ".png", ".jpeg" };

                string folderFullAddress = Server.MapPath("~/" + folder);
                DirectoryInfo dI = new DirectoryInfo(folderFullAddress);
                FileInfo[] fileInfo = dI.GetFiles();
                if (fileInfo.Length > 0)
                {
                    foreach (FileInfo fi in fileInfo)
                    {
                        if (imgeExt.Any(E => fi.Extension.ToUpper().Equals(E.ToUpper())))
                        {
                            imageList.Add(new Image { Name = fi.Name, ImageUrl = "/Media/" + fi.Name });
                        }
                    }


                }
            }

            return View("ImagesInFolder", imageList);
        }

    }
}