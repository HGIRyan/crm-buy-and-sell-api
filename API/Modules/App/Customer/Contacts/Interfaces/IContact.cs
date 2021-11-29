using API.MongoData.Model;
using API.MongoData.Models.Auth;

namespace API.SampleCustomers.Interfaces
{
    public interface IContact
    {
        #region Contacts

        Contact GetContact(string contactId);

        SampleCustomer GetSampleCustomerById(string mongoId);

        SampleCustomer CreateNewSampleCustomer(string username);
        SampleCustomer UpdateSampleCustomer(string mongoId, string username);
        
        #endregion
    }
}