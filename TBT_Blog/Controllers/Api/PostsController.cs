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

    public class PostsController : ApiController

    {
        BlogConnnectionDbContext _context;

        public PostsController()
        {
            _context = new BlogConnnectionDbContext();
        }


        [HttpGet]
        public IEnumerable<PostDto> Index()
        {
            return _context.Posts.Include(p => p.Author).ToList().Select(Mapper.Map<Post, PostDto>);
        }
        [HttpGet]
        public PostDto GetPost(int Id)
        {
            var post = _context.Posts.SingleOrDefault(P => P.Id == Id);
            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return Mapper.Map<Post, PostDto>(post);
        }

        [HttpPost]
        public IHttpActionResult CreatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var post = Mapper.Map<PostDto, Post>(postDto);
            _context.Posts.Add(post);
            _context.SaveChanges();

            postDto.Id = post.Id;

            return Created(new Uri(Request.RequestUri + "/" + postDto.Id), postDto);
        }

        [HttpPut]
        public IHttpActionResult UpdatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var postInDb = _context.Posts.SingleOrDefault(m => m.Id == postDto.Id);

            if (postInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(postDto, postInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void DeletePost(int Id)
        {
            Post postInDb = _context.Posts.SingleOrDefault(m => m.Id == Id);

            if (postInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Posts.Remove(postInDb);

            _context.SaveChanges();

        }
    }
}
