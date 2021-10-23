using System;
using API.Modules.App.Shared.Response;
using API.Modules.Base.Services;

namespace API.Modules.Base.Auth.Services
{
    public class AuthenticationService : BaseService, IAuthentication
    {
        public AuthenticationAPIServiceResponse CheckIfUserIsAuthorized(string userId)
        {
            if (!String.IsNullOrEmpty(userId))
            {
                return new AuthenticationAPIServiceResponse(true, "User Is Authorized");
            }
            else
            {
                return new AuthenticationAPIServiceResponse(false, "User Is Not Authorized");
            }
        }

        public AuthenticationAPIServiceResponse LogInUser(string username, string password)
        {
            return new AuthenticationAPIServiceResponse();
        }
    }
}