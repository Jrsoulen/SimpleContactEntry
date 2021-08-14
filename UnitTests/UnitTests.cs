using LiteDB;
using Newtonsoft.Json;
using SimpleContactEntry;
using System.IO;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        /*
        I recognize these tests don't test much
        These are just simple happy paths for TDD

        Normally I'd skip all these, since they change actual data
        I'm leaving them in since this is a sample app
        */

        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void CreateContact()
        {
            var json = File.ReadAllText(@"./Fixtures/SampleContact.json");
            Contact contact = JsonConvert.DeserializeObject<Contact>(json);

            LiteDBRepo dBRepo = new LiteDBRepo();
            var newContactId = dBRepo.CreateNewContact(contact);
            Assert.IsType<BsonValue>(newContactId);
        }

        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void UpdateContact()
        {
            var json = File.ReadAllText(@"./Fixtures/SampleContact.json");
            Contact contact = JsonConvert.DeserializeObject<Contact>(json);

            LiteDBRepo dBRepo = new LiteDBRepo();
            var isUpdated = dBRepo.UpdateExistingContact(1, contact);
            Assert.True(isUpdated);
        }

        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void DeleteContact()
        {
            LiteDBRepo dBRepo = new LiteDBRepo();
            var isDeleted = dBRepo.DeleteExistingContact(1);
            Assert.True(isDeleted);
        }

        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void GetContactById()
        {
            LiteDBRepo dBRepo = new LiteDBRepo();
            var contact = dBRepo.GetContactById(1);
            Assert.IsType<Contact>(contact);
        }

        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void GetAllContacts()
        {
            LiteDBRepo dBRepo = new LiteDBRepo();
            
            var contacts = dBRepo.GetAllContacts();
            
            // Helpful for debugging visibility
            var json = JsonConvert.SerializeObject(contacts).ToString();
            
            Assert.NotEmpty(contacts);
        }
    }
}
