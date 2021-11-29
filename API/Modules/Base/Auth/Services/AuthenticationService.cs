using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using API.Auth.Dto;
using API.Modules.App.Shared.Response;
using API.Modules.Base.Services;
using API.MongoData.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using API.Modules.Base.Services;

namespace API.Modules.Base.Auth.Services
{
    public class AuthenticationService : BaseService, IAuthentication
    {
        private readonly IUserInfo _userInfoService;

        public AuthenticationService(IUserInfo userInfoService)
        {
            _userInfoService = userInfoService;
        }


        public UserInfo CreateNewUser(IAuthManagerService authService, RegisterUserDto registerUserDto)
        {
            using var hmac = new HMACSHA512();

            UserInfo newUserInfo = new UserInfo()
            {
                Username = registerUserDto.Username.ToLower(),
                Email = registerUserDto.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password)),
                PasswordSalt = hmac.Key
            };
            return _userInfoService.Create(newUserInfo);
        }

        public UserDto LoginUser(IAuthManagerService authService, UserDto user)
        {
            var returnedUser = _userInfoService.FindByUsername(user.Username.ToLower());

            if (returnedUser == null)
                return new UserDto
                {
                    Message = "User Not Found",
                    IsSuccess = false
                };

            using var hmac = new HMACSHA512(returnedUser.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));

            if (computedHash.Where((t, i) => t != returnedUser.Password[i]).Any())
            {
                return new UserDto
                {
                    Message = "Password Incorrect",
                    IsSuccess = false
                };
            }

            return new UserDto(returnedUser)
            {
                UserToken = authService.CreateToken(returnedUser)
            };
        }
    }
}