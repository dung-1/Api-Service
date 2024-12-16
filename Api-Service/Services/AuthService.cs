using Api_Service.Common.Auth;
using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using Api_Service.Services.BaseSevice;
using Api_Service.Services.Jwt;
using Microsoft.AspNetCore.Identity;
namespace Api_Service.Services
{
    //public class AuthService : IAuthService
    //{
    //    private readonly IUserRepository _userRepository;
    //    private readonly IConfiguration _configuration;
    //    private readonly UserManager<UserAccount> _userManager;
    //    private readonly IJwtService _jwtService;
    //    public AuthService(IUserRepository userRepository, IJwtService jwtService, IConfiguration configuration, UserManager<UserAccount> userManager)
    //    {
    //        _userRepository = userRepository;
    //        _configuration = configuration;
    //        _userManager = userManager;
    //        _jwtService = jwtService;
    //    }

    //    public async Task<ServiceResponse<string>> RegisterAsync(RegisterDto model)
    //    {
    //        var response = new ServiceResponse<string>();
    //        var user = new UserAccount
    //        {
    //            Email = model.Email,
    //            UserName = model.Email,
    //            FullName = model.FullName,
    //            Role = Roles.Basic
    //        };

    //        var result = await _userRepository.CreateUserAsync(user, model.Password);
    //        if (result)
    //        {
    //            await _userManager.AddToRoleAsync(user, "Basic");
    //            response.Success = true;
    //            response.Message = "Registration successful";   
    //        }
    //        return response;
    //    }
    //    public Task LogoutAsync()
    //    {
    //        return Task.CompletedTask;
    //    }
    //    public async Task<ServiceResponse<LoginResponse>> LoginAsync(LoginDto model)
    //    {
    //        var response = new ServiceResponse<LoginResponse>();

    //        var user = await _userManager.FindByEmailAsync(model.Email);
    //        if (user == null)
    //        {
    //            response.Success = false;
    //            response.Message = "User not found";
    //            return response;
    //        }

    //        var result = await _userManager.CheckPasswordAsync(user, model.Password);
    //        if (!result)
    //        {
    //            response.Success = false;
    //            response.Message = "Invalid password";
    //            return response;
    //        }

    //        var token = await _jwtService.GenerateToken(user);
    //        response.Data = new LoginResponse
    //        {
    //            Token = token,
    //            Email = user.Email,
    //            FullName = user.FullName,
    //            Role = user.Role.ToString()
    //        };

    //        return response;
    //    }

    //}
}