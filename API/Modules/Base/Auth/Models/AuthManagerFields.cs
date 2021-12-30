using System;
using Microsoft.AspNetCore.Http;

namespace API.Modules.Base.Auth.Models
{
    public class AuthManagerFields
    {
        public const string LogoId = "LogoId";

        public Session InitializeSession(string logoId)
        {
            if (!String.IsNullOrEmpty(logoId))
                HttpSession.SetString(LogoId, logoId);
            return new Session()
            {
                LogoId = logoId
            };
        }

        public Session GetSession()
        {
            return new Session()
            {
                LogoId = HttpSession.GetString(LogoId)
            };
        }

        public void DestroySession()
        {
            HttpSession.Clear();
        }

        public class Session
        {
            public string LogoId { get; set; }
        }

        public HttpContext HttpContext { get; set; }
        public ISession HttpSession { get; set; }
    }
}