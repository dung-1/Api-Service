using Api_Service.Data;
using Api_Service.Model;
using Microsoft.EntityFrameworkCore;


namespace Api_Service.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
      return await _context.Users
          .FirstOrDefaultAsync(x => x.Username == username);
    }
  }
}