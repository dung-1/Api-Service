using Api_Service.Common.Auth;
using Api_Service.DTOs;
using Api_Service.Services.BaseSevice;

namespace Api_Service.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> RegisterAsync(RegisterDto model);
        Task<ServiceResponse<LoginResponse>> LoginAsync(LoginDto model);
        Task LogoutAsync();
    }
}
