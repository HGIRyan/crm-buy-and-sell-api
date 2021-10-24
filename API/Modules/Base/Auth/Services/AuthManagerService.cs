using API.Modules.Base.Auth.Models;

namespace API.Modules.Base.Auth.Services
{
    public class AuthManagerService : IAuthManagerService
    {
        public AuthManagerFields AuthManagerFields { get; set; }
        public void AddHeader(string key, string value)
        {
            throw new System.NotImplementedException();
        }
    }
}