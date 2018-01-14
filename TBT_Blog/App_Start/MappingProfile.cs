using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TBT_Blog.Dtos;
using TBT_Blog.Models;

namespace TBT_Blog.App_Start
{

    public static class MappingProfile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<MapProf>();
            });

        }
    }

    public class MapProf : Profile
    {
        public MapProf()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Post, Post>();
            CreateMap<PostDto, Post>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, Author>();
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorLikedPostDto, AuthorLikedPost>();
            CreateMap<AuthorLikedPost, AuthorLikedPostDto>();
        }

        //protected override void Configure()        //{        //    //For A.M 4.x:        //    CreateMap<StudentDto, Student>();        //    CreateMap<Student, StudentDto>();        //}
    }
}