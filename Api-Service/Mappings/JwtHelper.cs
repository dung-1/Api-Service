using Api_Service.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Service.Mappings
{
  public class JwtHelper
  {
    public static string GenerateToken(
        User user,
        IConfiguration configuration)
    {
      var claims = new[]
      {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

      var key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

      var creds = new SigningCredentials(
          key,
          SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          issuer: configuration["Jwt:Issuer"],
          audience: configuration["Jwt:Audience"],
          claims: claims,
          expires: DateTime.Now.AddHours(2),
          signingCredentials: creds
      );

      return new JwtSecurityTokenHandler()
          .WriteToken(token);
    }
  }
}