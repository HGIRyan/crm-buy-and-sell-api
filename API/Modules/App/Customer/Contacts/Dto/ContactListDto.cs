using API.MongoData.Model;
using System.Collections.Generic;

namespace API.Modules.App.Contacts.Dto
{
    public class ContactListDto
    {
        public IList<Contact> Contacts { get; set; }
        public long Count { get; set; }
    }
}