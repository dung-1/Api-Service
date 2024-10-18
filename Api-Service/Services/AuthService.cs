using Api_Service.DTOs;
using Api_Service.Model;
using Api_Service.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Api_Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserAccount> _userManager;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, UserManager<UserAccount> userManager)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto model)
        {
            var user = new UserAccount { UserName = model.Username, Email = model.Email };
            var result = await _userRepository.CreateUserAsync(user, model.Password);

            if (result)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = new List<string>()
                };
            }

            return null;
        }
        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }
        public async Task<string> LoginAsync(LoginDto model)
        {
            var user = await _userRepository.GetUserByUsernameAsync(model.Username);
            if (user != null && await _userRepository.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userRepository.GetUserRolesAsync(user);

                var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return null;
        }
    }
}