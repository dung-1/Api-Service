using Api_Service.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace Api_Service.Repository
{
    //public class UserRepository : IUserRepository
    //{
    //    private readonly UserManager<UserAccount> _userManager;

    //    public UserRepository(UserManager<UserAccount> userManager)
    //    {
    //        _userManager = userManager;
    //    }

    //    public async Task<UserAccount> GetUserByUsernameAsync(string username)
    //    {
    //        return await _userManager.FindByNameAsync(username);
    //    }

    //    public async Task<bool> CreateUserAsync(UserAccount user, string password)
    //    {
    //        var result = await _userManager.CreateAsync(user, password);
    //        return result.Succeeded;
    //    }

    //    public async Task<bool> CheckPasswordAsync(UserAccount user, string password)
    //    {
    //        return await _userManager.CheckPasswordAsync(user, password);
    //    }

    //    public async Task<IList<string>> GetUserRolesAsync(UserAccount user)
    //    {
    //        return await _userManager.GetRolesAsync(user);
    //    }
    //    public async Task<bool> CheckEmailExistsAsync(string email)
    //    {
    //        var user = await _userManager.FindByEmailAsync(email);
    //        return user != null;
    //    }
    //}

}
