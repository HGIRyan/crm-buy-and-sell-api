using System.Collections.Generic;
using API.Contacts.Interfaces;
using API.Modules.Base.Services;
using API.MongoData.Type;
using MongoDB.Driver;

namespace API.Contacts.Services
{
    public class ContactsService : BaseService, IContact
    {
        public Contact GetContact(string contactId)
        {
            return new Contact
            {
                MongoId = contactId
            };
        }

        public IEnumerable<SampleCustomers> GetContactByUsername(string username)
        {
            return MongoDbClients(username);
        }
        
        private IEnumerable<SampleCustomers> MongoDbClients(string username)
        {
            var client = new MongoClient("mongodb+srv://crm:qEfm4KMJ2p4d78a3@crm-buy-and-sell-api.mfzcs.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("sample_analytics");
            var collection = database.GetCollection<SampleCustomers>("customers");

            return collection.Find(s => s.username == username).ToList();
        }
    }
}