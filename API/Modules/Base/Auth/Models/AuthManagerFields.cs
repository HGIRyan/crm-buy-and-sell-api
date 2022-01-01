using System;
using Microsoft.AspNetCore.Http;

namespace API.Modules.Base.Auth.Models
{
    public class AuthManagerFields
    {
        public struct Constants
        {
            public const string LogoId = "LogoId";
            public const string UserId = "UserId";
        }

        public Session InitializeSession(string logoId, string userId)
        {
            if (!String.IsNullOrEmpty(logoId))
                HttpSession.SetString(Constants.LogoId, logoId);
            if (!String.IsNullOrEmpty(userId))
                HttpSession.SetString(Constants.UserId, userId);
            return new Session()
            {
                LogoId = logoId,
                UserId = userId
            };
        }

        public Session GetSession()
        {
            return new Session()
            {
                LogoId = HttpSession.GetString(Constants.LogoId),
                UserId = HttpSession.GetString(Constants.UserId)
            };
        }

        public void DestroySession()
        {
            HttpSession.Clear();
        }

        public class Session
        {
            public string LogoId { get; set; }
            public string UserId { get; set; }
        }

        public HttpContext HttpContext { get; set; }
        public ISession HttpSession { get; set; }
    }
}