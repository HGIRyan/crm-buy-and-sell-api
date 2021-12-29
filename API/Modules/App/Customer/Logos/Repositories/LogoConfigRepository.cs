using System.Collections.Generic;
using API.Modules.App.Customer.Logos.Interfaces;
using API.Modules.Base.Services;
using API.Modules.Base.Services.Mongo.MongoData;
using API.MongoData;
using API.MongoData.Model;
using MongoDB.Driver;

namespace API.Logos.Repositories
{
    public class LogoConfigRepository : BaseService, ILogoConfig
    {
        private readonly IMongoCollection<LogoConfig> _logoConfig;

        public LogoConfigRepository(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.MongoUri);
            var database = client.GetDatabase(Documents.Logo.Database);
            _logoConfig = database.GetCollection<LogoConfig>(Documents.Logo.LogoConfigCollection);
        }

        public LogoConfig Create(LogoConfig contact)
        {
            _logoConfig.InsertOne(contact);
            return contact;
        }

        public LogoConfig FindById(string mongoId)
        {
            return _logoConfig.Find(x => x.LogoConfigId == mongoId).SingleOrDefault();
        }


        public IList<LogoConfig> Read()
        {
            return _logoConfig.Find(x => true).ToList();
        }

        public void Update(LogoConfig contact)
        {
            _logoConfig.ReplaceOne(x => x.LogoConfigId == contact.LogoConfigId, contact);
        }

        public void Delete(string mongoId)
        {
            _logoConfig.DeleteOne(x => x.LogoConfigId == mongoId);
        }
    }
}