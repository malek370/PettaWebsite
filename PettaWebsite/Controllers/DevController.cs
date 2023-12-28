using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PettaWebsite.DTOs.AuthDTOs;
using PettaWebsite.DTOs.PetDTO;
using PettaWebsite.Models;
using PettaWebsite.Services.AuthServices;
using PettaWebsite.Services.PetServices;

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
        private readonly IPetService _petService;
        public DevController(IAuthService authService, UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager,IPetService petService) 
        {
            _petService = petService;
            _authService = authService;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin()
        {
            try
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Client));
                RegisterDTO reguser = new RegisterDTO()
                {
                    Username = "Admin",
                    Email = "admin@gmail.com",
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
        [HttpPost("AddDog")]
        public async Task<IActionResult> AddDog(AddDogDTO dog)
        {
            var result = await _petService.AddPet(dog);
            if(result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpPost("AddH")]
        public async Task<IActionResult> AddHorse(AddHorseDTO Horse)
        {
            var result = await _petService.AddPet(Horse);
            if (result.Success) { 
                return Ok(result); }
            else { return BadRequest(result); }
        }
    }
}
