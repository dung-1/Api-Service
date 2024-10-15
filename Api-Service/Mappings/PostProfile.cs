using Api_Service.DTOs;
using Api_Service.Model;
using AutoMapper;
namespace Api_Service.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            // Ánh xạ từ ProductDto sang Product và ngược lại
            CreateMap<PostDto, Post>()
                .ForMember(dest => dest.ExcerptImage, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ExcerptImage)));

            CreateMap<Post, PostDto>();
        }
    }
}
