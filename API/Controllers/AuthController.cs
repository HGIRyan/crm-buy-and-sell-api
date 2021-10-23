using API.Modules.App.Shared.Response;
using API.Modules.Base.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication
{
    public class AuthController : ControllerBase
    {
        
        #region Settings
        
        private IAuthentication _Authorization;

        public AuthController(IAuthentication Authorization)
        {
            _Authorization = Authorization;
        }

        #endregion

        #region Actions
        
        [HttpGet("/api/auth/CheckIfUserIsAuthorized")]
        [ProducesResponseType(typeof(AuthenticationAPIServiceResponse), StatusCodes.Status200OK)]
        public AuthenticationAPIServiceResponse CheckIfUserIsAuthorized(string userId)
        {
            return _Authorization.CheckIfUserIsAuthorized(userId);
        }
        
        #endregion
    }
}