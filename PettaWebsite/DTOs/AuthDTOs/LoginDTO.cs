using System.ComponentModel.DataAnnotations;

namespace PettaWebsite.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; } = "";
    }
}
