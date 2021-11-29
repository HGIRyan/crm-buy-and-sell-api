namespace API.Modules.Base.Services.Mongo.MongoData
{
    public interface IMongoSettings
    {
        string MongoUri { get; set; }
    }
    public class MongoSettings : IMongoSettings
    {
        public string MongoUri { get; set; }
    }
}