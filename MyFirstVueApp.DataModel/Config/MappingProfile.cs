using AutoMapper;
using MyFirstVueApp.Database.DTOs;
using MyFirstVueApp.Database.Models;

namespace MyFirstVueApp.Database.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }    
    }
}