using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.MongoData.Type
{
    [BsonIgnoreExtraElements]
    public class SampleCustomers
    {
        #region Properties

        [BsonId] 
        public ObjectId MongoId { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        [BsonElement("active")]
        public bool IsActive { get; set; }
        public List<int> accounts { get; set; }
        
        #endregion
    }
}