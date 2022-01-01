using API.Auth.Dto;
using API.Modules.Base.Auth.Models;
using API.MongoData.Model;

namespace API.Modules.App.Customer.Logos.Interfaces
{
    public interface ILogoConfigService
    {
        LogoConfig CreateLogoConfig(LogoConfig config);
        LogoConfig GetLogoConfig(string logoId);
        GlobalConfigDto GetGlobalConfig(AuthManagerFields authManager);
    }
}