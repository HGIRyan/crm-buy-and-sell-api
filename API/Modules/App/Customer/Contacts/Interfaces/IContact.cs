using API.Modules.Base.Auth;
using API.MongoData.Model;

namespace API.SampleCustomers.Interfaces
{
    public interface IContact
    {
        #region Contacts

        Contact GetContact(IAuthManagerService authService, string contactId);
        Contact AddContact(Contact contact);

        SampleCustomer GetSampleCustomerById(string mongoId);

        SampleCustomer CreateNewSampleCustomer(string username);
        SampleCustomer UpdateSampleCustomer(string mongoId, string username);
        
        #endregion
    }
}