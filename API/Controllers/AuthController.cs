using System.Threading.Tasks;
using API.Auth.Dto;
using API.Controllers;
using API.Modules.App.Shared.Response;
using API.Modules.Base.Auth;
using API.MongoData.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication
{
    public class AuthController : BaseApiController
    {
        #region Settings

        private readonly IAuthentication _authentication;

        public AuthController(IAuthentication authentication, IAuthManagerService authManager) : base(authManager)
        {
            _authentication = authentication;
        }

        #endregion

        #region Actions

        [HttpPost("/api/UserInfo/Register")]
        [ProducesResponseType(typeof(ActionResult<UserInfo>), StatusCodes.Status200OK)]
        public UserInfo CreateNewUser(RegisterUserDto registerUserDto)
        {
            return _authentication.CreateNewUser(_authManager, registerUserDto);
        }
        [HttpPost("/api/UserInfo/Login")]
        [ProducesResponseType(typeof(ActionResult<UserInfo>), StatusCodes.Status200OK)]
        public UserDto LoginUser(UserDto userDto)
        {
            return _authentication.LoginUser(_authManager, userDto);
        }

        #endregion
    }
}