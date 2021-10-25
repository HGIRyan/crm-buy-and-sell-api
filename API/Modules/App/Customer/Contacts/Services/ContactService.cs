using API.Modules.Base.Services;
using API.MongoData.Model;
using API.SampleCustomers.Interfaces;

namespace API.SampleCustomers.Services
{
    public class ContactsService : BaseService, IContact
    {
        private readonly ISampleCustomers _sampleCustomerService;
        public ContactsService(ISampleCustomers sampleCustomerService)
        {
            _sampleCustomerService = sampleCustomerService;
        }
        public Contact GetContact(string contactId)
        {
            return new Contact
            {
                MongoId = contactId
            };
        }
        public SampleCustomer GetSampleCustomerById(string mongoId)
        {
            return _sampleCustomerService.FindById(mongoId);
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