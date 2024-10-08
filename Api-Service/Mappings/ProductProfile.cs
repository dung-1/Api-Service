using Api_Service.DTOs;
using Api_Service.Model;
using AutoMapper;
namespace Api_Service.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Ánh xạ từ ProductDto sang Product và ngược lại

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
