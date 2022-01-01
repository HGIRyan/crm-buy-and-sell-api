using API.Auth.Dto;
using API.Modules.App.Customer.Logos.Interfaces;
using API.Modules.Base.Auth;
using API.Modules.Base.Auth.Models;
using API.MongoData.Model;

namespace API.Modules.App.Customer.Logos.Services
{
    public class LogoConfigService : ILogoConfigService
    {
        private readonly ILogoConfigRepository _logoConfigRepository;
        private readonly IUserInfoRepository _userInfoRepository;

        public LogoConfigService(ILogoConfigRepository logoConfigRepository, IUserInfoRepository userInfoRepository)
        {
            _logoConfigRepository = logoConfigRepository;
            _userInfoRepository = userInfoRepository;
        }

        public LogoConfig CreateLogoConfig(LogoConfig config)
        {
            return _logoConfigRepository.Create(config);
        }

        public LogoConfig GetLogoConfig(string logoId)
        {
            return _logoConfigRepository.FindById(logoId);
        }

        public GlobalConfigDto GetGlobalConfig(AuthManagerFields authManager)
        {
            var session = authManager.GetSession();
            if (session == null)
            {
                return new GlobalConfigDto()
                {
                    IsSuccess = false,
                    Message = "Session Not Found"
                };
            }

            var sessionUser = _userInfoRepository.FindById(session.UserId);
            var sessionLogo = _logoConfigRepository.FindById(session.LogoId);
            
            return new GlobalConfigDto(sessionUser, sessionLogo);
        }
    }
}