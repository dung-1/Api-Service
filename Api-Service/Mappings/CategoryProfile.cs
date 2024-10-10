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
            CreateMap<Category, CategoryDto>();
        }
    }
}
