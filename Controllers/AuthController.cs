using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManageAPI.Models;
using UserManageAPI.Services;

namespace UserManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var token = _authService.Authenticate(userLogin);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}