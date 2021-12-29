using System;
using API.Contacts.Interfaces;
using API.Modules.Base.Auth;
using API.Modules.Base.Services;
using API.MongoData.Model;
using API.SampleCustomers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace API.SampleCustomers.Services
{
    public class ContactsService : BaseService, IContact
    {
        private readonly ISampleCustomers _sampleCustomerService;
        private readonly IContactRepository _contactRepository;

        public ContactsService(ISampleCustomers sampleCustomerService, IContactRepository contactRepository)
        {
            _sampleCustomerService = sampleCustomerService;
            _contactRepository = contactRepository;
        }

        public Contact GetContact(IAuthManagerService authService, string contactId)
        {
            var logoId = authService.AuthManagerFields.GetSession();
            return _contactRepository.FindById(contactId);
        }

        public Contact AddContact(Contact contact)
        {
            return _contactRepository.Create(contact);
        }

        public SampleCustomer GetSampleCustomerById(string mongoId)
        {
            SampleCustomer sample = _sampleCustomerService.FindById(mongoId);
            if (sample == null)
            {
                throw new Exception("Sample Customer Not Found");
            }

            return sample;
        }

        public SampleCustomer CreateNewSampleCustomer(string username)
        {
            SampleCustomer newSampleCustomer = new SampleCustomer()
            {
                username = username
            };
            return _sampleCustomerService.Create(newSampleCustomer);
        }

        public SampleCustomer UpdateSampleCustomer(string mongoId, string name)
        {
            SampleCustomer sampleCustomer = _sampleCustomerService.FindById(mongoId);
            sampleCustomer.name = name;
            _sampleCustomerService.Update(sampleCustomer);
            return sampleCustomer;
        }
    }
}