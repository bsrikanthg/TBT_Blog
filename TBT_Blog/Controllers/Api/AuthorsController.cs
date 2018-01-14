using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using TBT_Blog.Dtos;
using TBT_Blog.Models;
using System.Threading;
using System.Threading.Tasks;

namespace TBT_Blog.Controllers.Api
{

    public class AuthorsController : ApiController
    {
        BlogConnnectionDbContext _context;
        public AuthorsController()
        {
            _context = new BlogConnnectionDbContext();
        }

        [HttpGet]
        public IEnumerable<AuthorDto> Index()
        {
            return _context.Authors.ToList().Select(Mapper.Map<Author, AuthorDto>);
        }


        [HttpPost]
        public IHttpActionResult CreateAuthor(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Author is invalid");
            }

            Author author = Mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
            authorDto.Id = author.Id;


            return Created(Request.RequestUri.AbsolutePath + "/" + authorDto.Id, authorDto);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            var author = _context.Authors.SingleOrDefault(A => A.Id == Id);

            if (author == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Authors.Remove(author);

            _context.SaveChanges();
        }
    }
}
