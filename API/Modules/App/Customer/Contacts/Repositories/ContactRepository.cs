using System;
using System.Collections.Generic;
using API.Contacts.Interfaces;
using API.Modules.Base.Services;
using API.Modules.Base.Services.Mongo.MongoData;
using API.MongoData;
using API.MongoData.Model;
using MongoDB.Driver;


namespace API.Contacts.Repositories
{
    public class ContactRepository : BaseService, IContactRepository
    {
        private readonly IMongoCollection<Contact> _contact;

        public ContactRepository(IMongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.MongoUri);
            var database = client.GetDatabase(Documents.Contacts.Database);
            _contact = database.GetCollection<Contact>(Documents.Contacts.Collection);
        }

        public Contact Create(Contact contact)
        {
            _contact.InsertOne(contact);
            return contact;
        }
        
        public Contact FindById(string mongoId, string logoId)
        {
            return _contact.Find(x => x.ContactId == mongoId && x.LogoId == logoId).SingleOrDefault();
        }


        public IList<Contact> Read()
        {
            return _contact.Find(x => true).ToList();
        }

        public void Update(Contact contact)
        {
            _contact.ReplaceOne(x => x.ContactId == contact.ContactId, contact);
        }

        public void Delete(string mongoId)
        {
            _contact.DeleteOne(x => x.ContactId == mongoId);
        }
    }
}