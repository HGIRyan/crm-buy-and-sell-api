using System.Collections.Generic;
using API.Contacts.Interfaces;
using API.Modules.App.Contacts.Dto;
using API.Modules.Base.Auth;
using API.Modules.Base.Services;
using API.MongoData.Model;
using API.SampleCustomers.Interfaces;

namespace API.Contacts.Services
{
    public class ContactsService : BaseService, IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactsService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact GetContact(IAuthManagerService authService, string contactId)
        {
            var logoId = authService.AuthManagerFields.GetSession().LogoId;
            return _contactRepository.FindById(contactId, logoId);
        }

        public IList<Contact> GetContacts(IAuthManagerService authService)
        {
            var logoId = authService.AuthManagerFields.GetSession().LogoId;
            return _contactRepository.FindByLogoId(logoId);
        }

        public ContactListDto GetContactList(IAuthManagerService authService, int page, int limit)
        {
            var logoId = authService.AuthManagerFields.GetSession().LogoId;
            var count = _contactRepository.getContactCount(logoId);
            var contacts = _contactRepository.FindByLogoIdAndLimitPage(logoId, page, limit);
            return new ContactListDto()
            {
                Count = count,
                Contacts = contacts
            };
        }

        public Contact AddContact(IAuthManagerService authService, Contact contact)
        {
            contact.LogoId = authService.AuthManagerFields.GetSession().LogoId;
            return _contactRepository.Create(contact);
        }
    }
}