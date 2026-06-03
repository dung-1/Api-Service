using Api_Service.DTOs;
using Api_Service.Mappings;
using Api_Service.Repository;

namespace Api_Service.Services
{
  public class AuthService : IAuthService
  {
    private readonly IUserRepository _userRepository;

    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IConfiguration configuration)
    {
      _userRepository = userRepository;
      _configuration = configuration;
    }

    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto request)
    {
      var user = await _userRepository
          .GetByUsernameAsync(request.Username);

      if (user == null)
      {
        return null;
      }

      // TEMP password check
      if (user.Password != request.Password)
      {
        return null;
      }

      var token = JwtHelper.GenerateToken(
          user,
          _configuration);

      return new LoginResponseDto
      {
        Token = token
      };
    }
  }
}