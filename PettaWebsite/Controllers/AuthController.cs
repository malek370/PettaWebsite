using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.AuthDTOs;
using PettaWebsite.Services.AuthServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loguser)
        {
            var res = await _authService.Login(loguser);
            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO reguser)
        {
            var res = await _authService.Register(reguser);
            if (res.Success) { return Ok(res); }
            return BadRequest(res);
        }
    }
}
