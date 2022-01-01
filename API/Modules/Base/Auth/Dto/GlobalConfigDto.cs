using System.ComponentModel.DataAnnotations;
using API.Modules.Base.Services;
using API.MongoData.Model;
using API.MongoData.Models.Auth;

namespace API.Auth.Dto
{
    public class GlobalConfigDto : ApiResponseDto
    {
        public GlobalConfigDto()
        {
        }

        public GlobalConfigDto(UserInfo user)
        {
            Email = user.Email;
            LogoId = user.LogoId;
            Username = user.Username;
        }

        public GlobalConfigDto(UserInfo user, LogoConfig logo)
        {
            Email = user.Email;
            LogoId = user.LogoId;
            Username = user.Username;
            LogoConfig = logo;
        }

        [EmailAddress] public string Email { get; set; }
        public string Username { get; set; }
        public string UserToken { get; set; }
        public string LogoId { get; set; }
        public LogoConfig LogoConfig { get; set; }
    }
}