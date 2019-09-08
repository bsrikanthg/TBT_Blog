using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TBT_Blog.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public FileUploadController()
        {

        }
        public ActionResult Index()
        {
            return View("Index", images);
        }


        //public ActionResult Upload(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        string serverFolder = Server.MapPath("Uploads");
        //        if (!Directory.Exists(serverFolder))
        //        {



        //            Directory.CreateDirectory(serverFolder);
        //        }

        //        file.SaveAs(serverFolder + "\\" + file.FileName);
        //        ViewBag.FileUrl = "~/" + serverFolder + "/" + file.FileName;
        //        ViewBag.Message = "File upload successful";
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "File upload not successful";
        //    }
        //    return View("Index");
        //}


        List<Models.Image> images = new List<Models.Image>();

        public ActionResult Upload()
        {
            ModelState.Clear();
            try
            {
                string serverFolder = Server.MapPath("~/Uploads");
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
                        images.Add(new Models.Image() { ImageUrl = "/Uploads/" + file.FileName, Name = file.FileName });
                    }

                    ViewBag.Message = "Files uploaded successfully.";
                }
                else
                {
                    ViewBag.Message = "No files.";
                }




            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload not successful";
            }
            return View("Index", images);
        }
    }
}