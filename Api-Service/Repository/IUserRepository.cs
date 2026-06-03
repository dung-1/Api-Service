using Api_Service.Model;

namespace Api_Service.Repository
{
  public interface IUserRepository
  {
    Task<User?> GetByUsernameAsync(string username);

  }
}
