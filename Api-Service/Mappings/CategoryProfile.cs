using Api_Service.DTOs;
using Api_Service.Model;
using AutoMapper;

namespace Api_Service.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Ánh xạ từ CategoryDto sang Category và ngược lại
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
        }
    }
}
