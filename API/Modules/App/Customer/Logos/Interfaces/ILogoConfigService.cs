using API.MongoData.Model;

namespace API.Modules.App.Customer.Logos.Interfaces
{
    public interface ILogoConfigService
    {
        LogoConfig CreateLogoConfig(LogoConfig config);
    }
}