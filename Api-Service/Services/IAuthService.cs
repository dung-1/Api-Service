using Api_Service.DTOs;

namespace Api_Service.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
        Task LogoutAsync();
    }
}
