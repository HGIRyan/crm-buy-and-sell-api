using System.Threading.Tasks;
using API.Auth.Dto;
using API.Modules.App.Shared.Response;
using API.MongoData.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Base.Auth
{
    public interface IAuthentication
    {
        #region Authentication

        UserInfo CreateNewUser(IAuthManagerService authService, RegisterUserDto registerUserDto);

        UserDto LoginUser(IAuthManagerService authService, UserDto userDto);

        #endregion

    }
    
}