using API.Modules.Base.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.MongoData.Models.Auth
{
    [BsonIgnoreExtraElements]
    public class UserInfo
    {
        public UserInfo()
        {
        }

        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string LogoId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }

        #endregion
    }
}