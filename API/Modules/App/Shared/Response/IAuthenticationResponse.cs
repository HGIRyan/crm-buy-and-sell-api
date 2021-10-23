namespace API.Modules.App.Shared.Response
{
    public class AuthenticationAPIServiceResponse
    {
        #region Constructors

        public AuthenticationAPIServiceResponse()
        {
            this.isAuthorized = false;
        }

        public AuthenticationAPIServiceResponse(bool isSuccess, string message)
        {
            this.isAuthorized = false;
            this.isSuccess = isSuccess;
            this.message = message;
        }
        #endregion

        #region Properties

        public bool isSuccess { get; set; }
        public string message { get; set; }
        public bool isAuthorized { get; set; }

        #endregion
    }
}