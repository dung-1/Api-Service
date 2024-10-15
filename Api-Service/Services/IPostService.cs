using Api_Service.DTOs;

namespace Api_Service.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto> GetByIdAsync(int id);
        Task<PostDto> AddAsync(PostDto productDto);
        Task<PostDto> UpdateAsync(PostDto productDto, IFormFile imageFile);
        Task<bool> DeleteAsync(int id);
        Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
