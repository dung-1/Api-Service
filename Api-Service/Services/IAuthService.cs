using Api_Service.DTOs;

namespace Api_Service.Services
{
  public interface IAuthService
  {
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);

  }
}
