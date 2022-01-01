using System.Collections.Generic;
using API.Modules.App.Contacts.Dto;
using API.Modules.Base.Auth;
using API.MongoData.Model;

namespace API.SampleCustomers.Interfaces
{
    public interface IContactService
    {
        #region Contacts

        Contact GetContact(IAuthManagerService authService, string contactId);
        IList<Contact> GetContacts(IAuthManagerService authService);
        ContactListDto GetContactList(IAuthManagerService authService, int page, int limit);
        Contact AddContact(IAuthManagerService authService, Contact contact);

        #endregion
    }
}