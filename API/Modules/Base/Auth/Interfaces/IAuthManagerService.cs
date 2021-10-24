using API.Modules.Base.Auth.Models;

namespace API.Modules.Base.Auth
{
    public interface IAuthManagerService
    {
        #region Properties

        public AuthManagerFields AuthManagerFields { get; set; }

        #endregion
        
        #region Methods

        void AddHeader(string key, string value);

        #endregion
    }
}