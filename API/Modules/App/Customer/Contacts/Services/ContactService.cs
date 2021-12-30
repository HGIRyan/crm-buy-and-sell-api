using System;
using System.Collections.Generic;
using API.Contacts.Interfaces;
using API.Modules.Base.Auth;
using API.Modules.Base.Services;
using API.MongoData.Model;
using API.SampleCustomers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace API.SampleCustomers.Services
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

        public Contact AddContact(IAuthManagerService authService, Contact contact)
        {
            contact.LogoId = authService.AuthManagerFields.GetSession().LogoId;
            return _contactRepository.Create(contact);
        }
    }
}