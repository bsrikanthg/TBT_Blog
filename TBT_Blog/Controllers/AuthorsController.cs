using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBT_Blog.Models;

namespace TBT_Blog.Controllers
{
    public class AuthorsController : Controller
    {
        TBT_Blog.Models.BlogConnnectionDbContext _context;
        public AuthorsController()
        {
            _context = new Models.BlogConnnectionDbContext();
        }
        // GET: Authors
        public ActionResult Index()
        {
           // IEnumerable<Author> authors = _context.Authors.ToList();
            return View("Index_api",  null);
        }

        [Authorize]
        public ActionResult CreateAuthor()
        {
            Author author = new Author();
            return View(author);
        }

        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAuthor", new Author());
            }

            if (author.Id == 0)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }

}