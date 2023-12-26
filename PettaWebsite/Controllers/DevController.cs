using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.AuthDTOs;
using PettaWebsite.Models;
using PettaWebsite.Services.AuthServices;

namespace PettaWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        public DevController(IAuthService authService, UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager) 
        {
            _authService = authService;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost("one")]
        public async Task<IActionResult> one()
        {
            try
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                RegisterDTO reguser = new RegisterDTO()
                {
                    Username = "Admin",
                    Email = "admin@gamil.com",
                    Password = "Admin@123",
                    ConfirmPassword = "Admin@123",
                    PhoneNumber = "29491822"
                };
                var user = new IdentityUser()
                {
                    UserName = reguser.Username,
                    Email = reguser.Email,
                    PhoneNumber = reguser.PhoneNumber,
                };
                var created = await _userManager.CreateAsync(user, reguser.Password);
                await _userManager.AddToRoleAsync(user, Roles.Admin);
                await _userManager.AddToRoleAsync(user, Roles.Client);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); } 
        }
    }
}
