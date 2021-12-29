using API.Modules.App.Customer.Logos.Interfaces;
using API.MongoData.Model;

namespace API.Modules.App.Customer.Logos.Services
{
    public class LogoConfigService : ILogoConfigService
    {
        private readonly ILogoConfigRepository _logoConfigRepository;

        public LogoConfigService(ILogoConfigRepository logoConfigRepository)
        {
            _logoConfigRepository = logoConfigRepository;
        }

        public LogoConfig CreateLogoConfig(LogoConfig config)
        {
            return _logoConfigRepository.Create(config);
        }
    }
}