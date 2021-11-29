using API.SampleCustomers.Interfaces;
using API.Controllers;
using API.Modules.Base.Auth;
using API.MongoData.Model;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize]
        [HttpGet("/api/SampleCustomer/Find")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public SampleCustomer GetSampleCustomerById(string mongoId)
        {
            return _Contact.GetSampleCustomerById(mongoId);
        }
        
        [HttpGet("/api/SampleCustomer/Create")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public SampleCustomer CreateNewSampleCustomer(string username)
        {
            return _Contact.CreateNewSampleCustomer(username);
        }

        [HttpGet("/api/SampleCustomer/Update")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public SampleCustomer UpdateSampleCustomer(string mongoId, string username)
        {
            var account = _authManager;
            return _Contact.UpdateSampleCustomer(mongoId, username);
        }
    }
}