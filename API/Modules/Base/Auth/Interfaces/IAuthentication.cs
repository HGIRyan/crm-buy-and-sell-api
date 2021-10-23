using API.Modules.App.Shared.Response;

namespace API.Modules.Base.Auth
{
    public interface IAuthentication
    {
        #region Authentication

        AuthenticationAPIServiceResponse CheckIfUserIsAuthorized(string userId);

        #endregion

    }
    
}