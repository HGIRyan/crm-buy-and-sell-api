using System;
using MongoDB.Bson.Serialization.Attributes;

namespace API.MongoData.Model
{
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
        public string MongoId { get; set; }
        public string DocType { get; set; }
        public string ContactType { get; set; }
        public string CreatedBy { get; set; }
        public int DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        #endregion        
    }
}
