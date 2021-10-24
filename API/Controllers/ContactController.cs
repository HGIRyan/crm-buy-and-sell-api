using API.Contacts.Interfaces;
using API.Controllers;
using API.Modules.Base.Auth;
using API.MongoData.Type;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication
{
    public class ContactController : BaseApiController
    {
        private readonly IContact _Contact;

        public ContactController(IContact contact, IAuthManagerService authManager) : base(authManager)
        {
            _Contact = contact;
        }

        [HttpGet("/api/contact/GetContact")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public Contact GetContact(string contactId)
        {
            return _Contact.GetContact(contactId);
        }
    }
}