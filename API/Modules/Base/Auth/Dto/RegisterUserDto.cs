using System.ComponentModel.DataAnnotations;
using API.Modules.Base.Services;

namespace API.Auth.Dto
{
    public class RegisterUserDto : ApiResponseDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}