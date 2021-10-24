using API.MongoData.Type;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Modules.Base.Services.Mongo
{
    public class MongoDbClient
    {
        public IMongoCollection<SampleCustomers> MongoDbClients()
        {
            var client = new MongoClient("mongodb+srv://crm:qEfm4KMJ2p4d78a3@crm-buy-and-sell-api.mfzcs.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("sample_analytics");
            var collection = database.GetCollection<SampleCustomers>("customers");

            collection.Find(s => s.username == "fmiller");
            return collection;
        }
        
    }
}