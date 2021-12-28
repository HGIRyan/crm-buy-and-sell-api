using System.Security.Claims;
using API.Modules.Base.Auth.Models;
using API.MongoData.Models.Auth;

namespace API.Modules.Base.Auth
{
    public interface IAuthManagerService
    {
        #region Properties

        public AuthManagerFields AuthManagerFields { get; set; }

        #endregion
        
        #region Methods

        void AddHeader(string key, string value);

        string CreateToken(UserInfo user);

        ClaimsPrincipal GetPrincipalFromToken(string token);

        #endregion
    }
}