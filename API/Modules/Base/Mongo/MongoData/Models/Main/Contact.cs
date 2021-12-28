using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.MongoData.Model
{
    [BsonIgnoreExtraElements]
    public class Contact
    {
        #region Constructors
        public const string DOCUMENT_TYPE = "contact";
        public Contact()
        {
            this.DocType = DOCUMENT_TYPE;
            this.DateCreated = (int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        #endregion

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string LogoId { get; set; }
        public string DocType { get; set; }
        public bool IsPrimary { get; set; }
        public string ContactType { get; set; }
        public string ContactStatus { get; set; }
        public string CreatedBy { get; set; }
        public int DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string[] Projects { get; set; }

        #endregion        
    }
}
