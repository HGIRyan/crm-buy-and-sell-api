using System.Collections.Generic;
using API.Modules.Base.Services;
using API.Modules.Base.Services.Mongo.MongoData;
using API.MongoData;
using API.MongoData.Model;
using API.SampleCustomers.Interfaces;
using MongoDB.Driver;

namespace API.Customers.SampleCustomers.Service
{
    public class SampleCustomerService : BaseService, ISampleCustomers
    {
        private readonly IMongoCollection<SampleCustomer> _sampleCustomer;

        public SampleCustomerService(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.MongoUri);
            var database = client.GetDatabase(Documents.SampleCustomers.Database);
            _sampleCustomer = database.GetCollection<SampleCustomer>(Documents.SampleCustomers.Collection);
        }

        public SampleCustomer Create(SampleCustomer sampleCustomer)
        {
            _sampleCustomer.InsertOne(sampleCustomer);
            return sampleCustomer;
        }

        public SampleCustomer FindById(string mongoId)
        {
            return _sampleCustomer.Find(x => x.MongoId == mongoId).SingleOrDefault();
        }


        public IList<SampleCustomer> Read()
        {
            return _sampleCustomer.Find(x => true).ToList();
        }

        public void Update(SampleCustomer sampleCustomer)
        {
            _sampleCustomer.ReplaceOne(x => x.MongoId == sampleCustomer.MongoId, sampleCustomer);
        }

        public void Delete(string mongoId)
        {
            _sampleCustomer.DeleteOne(x => x.MongoId == mongoId);
        }
    }
}