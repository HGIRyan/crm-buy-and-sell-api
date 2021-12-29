using System.Collections.Generic;
using API.Modules.Base.Auth;
using API.Modules.Base.Services;
using API.Modules.Base.Services.Mongo.MongoData;
using API.MongoData;
using API.MongoData.Models.Auth;
using MongoDB.Driver;

namespace API.Auth.Repository
{
    public class UserInfoRepositoryRepository : BaseService, IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _userInfo;

        public UserInfoRepositoryRepository(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.MongoUri);
            var database = client.GetDatabase(Documents.UserInfo.Database);
            _userInfo = database.GetCollection<UserInfo>(Documents.UserInfo.Collection);
        }
        
        public UserInfo Create(UserInfo user)
        {
            _userInfo.InsertOne(user);
            return user;
        }

        public UserInfo FindById(string mongoId)
        {
            return _userInfo.Find(x => x.MongoId == mongoId).FirstOrDefault();
        }
        
        public UserInfo FindByUsername(string username)
        {
            return _userInfo.Find(x => x.Username == username).FirstOrDefault();
        }

        public UserInfo FindByEmail(string email)
        {
            return _userInfo.Find(x => x.Email == email).FirstOrDefault();
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