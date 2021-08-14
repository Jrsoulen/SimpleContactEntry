using System;
using System.Collections.Generic;
using LiteDB;

namespace SimpleContactEntry
{
    public class LiteDBRepo
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                return db.GetCollection<Contact>("contacts").Query().ToList();
            }
        }
        public Contact GetContactById(int id)
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                var contact = db.GetCollection<Contact>("contacts").FindById(id);
                if (contact is null) throw new Exception($"Contact with id {id} not found.");
                return contact;

            }
        }
        public BsonValue CreateNewContact(Contact contact)
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                var contactCollection = db.GetCollection<Contact>("contacts");
                return contactCollection.Insert(contact);
            }
        }

        public bool UpdateExistingContact(int id, Contact contact)
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                var isUpdated = db.GetCollection<Contact>("contacts").Update(id, contact);
                if (!isUpdated) throw new Exception($"Contact with id {id} not found.");
                return isUpdated;

            }
        }
        public bool DeleteExistingContact(int id)
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                var isDeleted = db.GetCollection<Contact>("contacts").Delete(id);
                if (!isDeleted) throw new Exception($"Contact with id {id} not found.");
                return isDeleted;
            }
        }
    }
}
