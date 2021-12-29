using API.SampleCustomers.Interfaces;
using API.Controllers;
using API.Modules.Base.Auth;
using API.MongoData.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication
{
    [Authorize]
    public class ContactController : BaseApiController
    {
        private readonly IContact _contact;

        public ContactController(IContact contact, IAuthManagerService authManager) : base(authManager)
        {
            _contact = contact;
        }

        [HttpGet("/api/contact/GetContact")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetContact(string contactId)
        {
            return Ok(_contact.GetContact(_authManager, contactId));
        }

        [HttpPost("/api/contact/AddContact")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AddContact(Contact contact)
        {
            return Ok(_contact.AddContact(contact));
        }

        [HttpGet("/api/SampleCustomer/Find")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public IActionResult GetSampleCustomerById(string mongoId)
        {
            return Ok(_contact.GetSampleCustomerById(mongoId));
        }

        [HttpGet("/api/SampleCustomer/Create")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public SampleCustomer CreateNewSampleCustomer(string username)
        {
            return _contact.CreateNewSampleCustomer(username);
        }

        [HttpGet("/api/SampleCustomer/Update")]
        [ProducesResponseType(typeof(SampleCustomer), StatusCodes.Status200OK)]
        public SampleCustomer UpdateSampleCustomer(string mongoId, string username)
        {
            var account = _authManager;
            return _contact.UpdateSampleCustomer(mongoId, username);
        }
    }
}