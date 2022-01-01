using System.ComponentModel.DataAnnotations;
using API.Modules.Base.Services;
using API.MongoData.Models.Auth;

namespace API.Auth.Dto
{
    public class UserDto
    {
        public UserDto()
        {
        }

        public UserDto(UserInfo user)
        {
            Email = user.Email;
            Password = "ENCRYPTED PASSWORD";
        }

        [EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}