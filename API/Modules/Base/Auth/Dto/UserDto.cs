using System.ComponentModel.DataAnnotations;
using API.Modules.Base.Services;
using API.MongoData.Models.Auth;

namespace API.Auth.Dto
{
    public class UserDto : ApiResponseDto
    {
        public UserDto() {}
        public UserDto(UserInfo user)
        {
            Username = user.Username;
            Email = user.Email;
            Password = "ENCRYPTED PASSWORD";
        }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserToken { get; set; }
    }
}