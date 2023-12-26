using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PettaWebsite.DTOs;
using PettaWebsite.DTOs.AuthDTOs;
using PettaWebsite.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PettaWebsite.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        /*
         admin account: 
        {
          "username": "Admin",
          "email": "admin@gamil.com",
          "password": "Admin@123",
          "confirmPassword": "Admin@123",
          "phoneNumber": "29491822"
        }
         */
        public async Task<Response<object>> Register(RegisterDTO reguser)
        {
            var result = new Response<object>();
            try
            {
                //to delete
                //await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                //await _roleManager.CreateAsync(new IdentityRole(Roles.Client));
                if (await _userManager.FindByEmailAsync(reguser.Email) != null) { throw new Exception("user exists"); }
                if(!reguser.Password.Equals(reguser.ConfirmPassword)) { throw new Exception("Password not confirmed"); }
                var user = new IdentityUser()
                {
                    UserName = reguser.Username,
                    Email = reguser.Email,
                    PhoneNumber = reguser.PhoneNumber,
                };
                var created = await _userManager.CreateAsync(user, reguser.Password);
                //to delete
                //await _userManager.AddToRoleAsync(user, Roles.Admin);

                await _userManager.AddToRoleAsync(user, Roles.Client);
                if (!created.Succeeded) { throw new Exception(created.Errors.FirstOrDefault()!.Description.ToString()); }
                result.Message = "registredf successfully";
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        public async Task<Response<string>> Login(LoginDTO loguser)
        {
            var result = new Response<string>();
            try
            {
                var user = await _userManager.FindByEmailAsync(loguser.Email);
                if (user == null) { throw new Exception("user not found"); }
                if (!await _userManager.CheckPasswordAsync(user, loguser.Password)) throw new Exception("password incorrect");
                result.Message = "login successfuly";
                result.Data = await GenerateToken(user);
            }
            catch (Exception ex) { result.Message = ex.Message; result.Success = false; }
            return result;
        }

        private async Task<string> GenerateToken(IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, user.Email!),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]!));
            var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
                //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
                Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(authClaims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}