using Api_Service.DTOs;

namespace Api_Service.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> AddAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
    }
}
