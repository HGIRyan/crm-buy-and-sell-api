using API.SampleCustomers.Interfaces;
using API.Modules.Base.Auth;
using API.MongoData.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ContactController : BaseApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService, IAuthManagerService authManager) : base(authManager)
        {
            _contactService = contactService;
        }

        [HttpGet("/api/contact/GetContact")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetContact(string contactId)
        {
            return Ok(_contactService.GetContact(_authManager, contactId));
        }

        [HttpGet("/api/contact/GetContacts")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetContacts()
        {
            return Ok(_contactService.GetContacts(_authManager));
        }

        [HttpPost("/api/contact/AddContact")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AddContact(Contact contact)
        {
            return Ok(_contactService.AddContact(_authManager, contact));
        }
    }
}