using API.Modules.Base.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Settings

        public IAuthManagerService _authManager;

        #endregion

        #region Constructors

        public BaseApiController(IAuthManagerService authManager)
        {
            _authManager = authManager;
        }

        #endregion
    }
}