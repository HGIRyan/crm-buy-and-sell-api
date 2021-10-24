using API.MongoData.Type;

namespace API.Contacts.Interfaces
{
    public interface IContact
    {
        #region Contacts

        Contact GetContact(string contactId);

        #endregion
    }
}