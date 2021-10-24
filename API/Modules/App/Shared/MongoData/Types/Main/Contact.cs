using System;

namespace API.MongoData.Type
{
    public class Contact
    {
        #region Constructors
        public const string DOCUMENT_TYPE = "contact";
        public Contact()
        {
            this.doc_type = DOCUMENT_TYPE;
            this.date_created = (int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        #endregion

        #region Properties
        public string mongoId { get; set; }
        public string doc_type { get; set; }
        public string contact_type { get; set; }
        public string created_by { get; set; }
        public int date_created { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        
        #endregion        
    }
}
