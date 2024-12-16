using Api_Service.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Service.Services.Jwt
{
    //public class JwtService : IJwtService
    //{
    //    private readonly IConfiguration _config;

    //    private readonly UserManager<UserAccount> _userManager;


    //    public JwtService(IConfiguration config, UserManager<UserAccount> userManager)
    //    {
    //        _config = config;
    //        _userManager = userManager;
    //    }

    //    public async Task<string> GenerateToken(UserAccount user)
    //    {
    //        var roles = await _userManager.GetRolesAsync(user);

    //        var claims = new List<Claim>
    //    {
    //        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
    //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
    //        new Claim(JwtRegisteredClaimNames.Name, user.FullName)
    //    };

    //        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    //        var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)), SecurityAlgorithms.HmacSha256);
    //        var token = new JwtSecurityToken(
    //            issuer: _config["JWT:Issuer"],
    //            claims: claims,
    //            expires: DateTime.Now.AddMinutes(double.Parse(_config["Jwt:ExpiryMinutes"]!)),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    //}
}
