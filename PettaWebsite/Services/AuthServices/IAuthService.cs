using PettaWebsite.DTOs;
using PettaWebsite.DTOs.AuthDTOs;

namespace PettaWebsite.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Response<string>> Login(LoginDTO loguser);
        Task<Response<object>> Register(RegisterDTO reguser);
    }
}