using API.Modules.App.Customer.Logos.Interfaces;
using API.Modules.Base.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class LogoConfigController : BaseApiController
    {
        private readonly ILogoConfigService _logoConfigService;

        public LogoConfigController(IAuthManagerService authManager, ILogoConfigService logoConfigService) : base(authManager)
        {
            _logoConfigService = logoConfigService;
        }

        [HttpGet("/api/LogoConfig/globalConfig")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetLogoConfig()
        {
            return Ok(_logoConfigService.GetGlobalConfig(_authManager.AuthManagerFields));
        }
    }
}