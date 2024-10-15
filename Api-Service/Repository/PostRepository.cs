using Api_Service.Data;
using Api_Service.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Service.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.Include(p => p.Category).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> AddAsync(Post product)
        {
            await _context.Posts.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Post> UpdateAsync(Post product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Posts.FindAsync(id);
            if (product == null) return false;

            _context.Posts.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

