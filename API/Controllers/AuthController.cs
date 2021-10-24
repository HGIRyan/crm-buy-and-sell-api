using API.Controllers;
using API.Modules.App.Shared.Response;
using API.Modules.Base.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication
{
    public class AuthController : BaseApiController
    {
        
        #region Settings
        
        private readonly IAuthentication _Authorization;

        public AuthController(IAuthentication Authorization, IAuthManagerService authManager) : base(authManager)
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