using Api_Service.Model;

namespace Api_Service.Repository
{
    public interface IPostRepository
    {

        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> AddAsync(Post post);
        Task<Post> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);

    }
}
