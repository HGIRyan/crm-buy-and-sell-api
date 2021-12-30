using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.MongoData.Model
{
    [BsonIgnoreExtraElements]
    public class LogoConfig
    {
        public LogoConfig()
        {
            this.DocType = Documents.Logo.LogoConfigCollection;
        }

        public string DocType { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LogoConfigId { get; set; }

        public string[] Users { get; set; } = Array.Empty<string>();
        public decimal? RecurringAmount { get; set; }
        public int? RecurringMonths { get; set; }
        public long? NextPaymentDate { get; set; }
        public decimal Discount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}