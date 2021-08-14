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
                var contacts = db.GetCollection<Contact>("contacts");
                return contacts.FindById(id);
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
                return db.GetCollection<Contact>("contacts").Update(id, contact);
            }
        }
        public bool DeleteExistingContact(int id)
        {
            using (var db = new LiteDatabase(@".\SimpleContacts.db"))
            {
                return db.GetCollection<Contact>("contacts").Delete(id);
            }
        }
    }
}
