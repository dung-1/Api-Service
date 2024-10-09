using Api_Service.DTOs;

namespace Api_Service.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task<ProductDto> UpdateAsync(ProductDto productDto, IFormFile imageFile);
        Task<bool> DeleteAsync(int id);
        Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
