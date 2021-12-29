using Microsoft.AspNetCore.Http;

namespace API.Modules.Base.Auth.Models
{
    public class AuthManagerFields
    {
        
        public string LogoId { get; set; }
        public HttpContext HttpContext { get; set; }
        public ISession Session { get; set; }
    }
}