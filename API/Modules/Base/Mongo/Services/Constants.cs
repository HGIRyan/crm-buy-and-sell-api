namespace API.MongoData
{
    public struct Documents
    {
        public struct SampleCustomers
        {
            public const string Database = "sample_analytics";
            public const string Collection = "customers";
        }

        public struct UserInfo
        {
            public const string Database = "user";
            public const string Collection = "user_info";
        }

        public struct Contacts
        {
            public const string Database = "contacts";
            public const string Collection = "contacts";
        }

        public struct Logo
        {
            public const string Database = "logo";
            public const string LogoConfigCollection = "logo_config";
        }
    }
}