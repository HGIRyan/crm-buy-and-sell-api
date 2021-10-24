using API.Contacts.Interfaces;
using API.Modules.Base.Services;
using API.MongoData.Type;

namespace API.Contacts.Services
{
    public class ContactsService : BaseService, IContact
    {
        public Contact GetContact(string contactId)
        {
            return new Contact
            {
                mongoId = contactId
            };
        }
    }
}