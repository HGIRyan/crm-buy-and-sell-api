using System.Collections.Generic;
using API.MongoData.Model;

namespace API.Contacts.Interfaces
{
    public interface IContactRepository
    {
        Contact Create(Contact sampleCustomer);
        Contact FindById(string mongoId, string logoId);
        IList<Contact> FindByLogoId(string logoId);
        IList<Contact> Read();
        void Update(Contact sampleCustomer);
        void Delete(string mongoDb);
    }
}