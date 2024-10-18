using Api_Service.Model;

namespace Api_Service.Repository
{
    public interface IUserRepository
    {
        Task<UserAccount> GetUserByUsernameAsync(string username);
        Task<bool> CreateUserAsync(UserAccount user, string password);
        Task<bool> CheckPasswordAsync(UserAccount user, string password);
        Task<IList<string>> GetUserRolesAsync(UserAccount user);
    }
}
