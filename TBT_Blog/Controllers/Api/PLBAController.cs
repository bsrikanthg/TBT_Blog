using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TBT_Blog.Dtos;
using TBT_Blog.Models;
using System.Data.Entity;

namespace TBT_Blog.Controllers.Api
{
    public class PLBAController : ApiController
    {
        BlogConnnectionDbContext _context;

        public PLBAController()
        {
            _context = new Models.BlogConnnectionDbContext();
        }

        [HttpGet]
        public IEnumerable<AuthorLikedPostDto> Index()
        {
            return _context.AuthorLikedPosts.Include(I => I.Author).Include(J => J.Post).Select(Mapper.Map<AuthorLikedPost, AuthorLikedPostDto>);
        }

        [HttpGet]
        public IEnumerable<AuthorLikedPostDto> GetPostLikedByAuthor(int Id)
        {
            Author authorinDb = _context.Authors.SingleOrDefault(a => a.Id == Id);

            if (authorinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            IEnumerable<AuthorLikedPostDto> postLikedByAuthors = _context.AuthorLikedPosts.Where(i => i.Author.Id == Id).Include(I => I.Author).Include(J => J.Post).Select(Mapper.Map<AuthorLikedPost, AuthorLikedPostDto>).ToList();

            return postLikedByAuthors;
        }


        public IHttpActionResult SetPostsLikedByAuthor(AuthorLikedPostDto alp)
        {
            var author = _context.Authors.Where(A => A.Id == alp.AuthorId).SingleOrDefault();

            if (author == null)
            {
                return BadRequest("Author doesnot exists.");
            }

            var posts = _context.Posts.Where(p => alp.PostIds.Contains(p.Id)).ToList();

            if (posts == null)
            {
                return BadRequest("Posts Ids are not sent.");
            }

            foreach (Post p in posts)
            {
                _context.AuthorLikedPosts.Add(new AuthorLikedPost
                {
                    Author = author,
                    Post = p,
                    DateLiked = DateTime.Now
                });
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
