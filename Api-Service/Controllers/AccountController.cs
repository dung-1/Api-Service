using Api_Service.DTOs;
using Api_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var result = await _authService.RegisterAsync(model);
            if (result != null)
                return Ok(result);
            return BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _authService.LoginAsync(model);
            if (token != null)
                return Ok(new { token });
            return Unauthorized();
        }
  

    [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok();
        }
    }

}
