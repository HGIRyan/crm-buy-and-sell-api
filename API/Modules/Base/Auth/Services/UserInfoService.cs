using System.Collections.Generic;
using API.Modules.Base.Auth;
using API.Modules.Base.Services;
using API.Modules.Base.Services.Mongo.MongoData;
using API.MongoData;
using API.MongoData.Models.Auth;
using MongoDB.Driver;

namespace API.Auth.Services
{
    public class UserInfoService : BaseService, IUserInfo
    {
        private readonly IMongoCollection<UserInfo> _userInfo;

        public UserInfoService(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.MongoUri);
            var database = client.GetDatabase(Documents.UserInfo.Database);
            _userInfo = database.GetCollection<UserInfo>(Documents.UserInfo.Collection);
        }
        
        public UserInfo Create(UserInfo sampleCustomer)
        {
            _userInfo.InsertOne(sampleCustomer);
            return sampleCustomer;
        }

        public UserInfo FindById(string mongoId)
        {
            return _userInfo.Find(x => x.MongoId == mongoId).SingleOrDefault();
        }
        
        public UserInfo FindByUsername(string username)
        {
            return _userInfo.Find(x => x.Username == username).SingleOrDefault();
        }


        public IList<UserInfo> Read()
        {
            return _userInfo.Find(x => true).ToList();
        }

        public void Update(UserInfo sampleCustomer)
        {
            _userInfo.ReplaceOne(x => x.MongoId == sampleCustomer.MongoId, sampleCustomer);
        }

        public void Delete(string mongoId)
        {
            _userInfo.DeleteOne(x => x.MongoId == mongoId);
        }
    }
}