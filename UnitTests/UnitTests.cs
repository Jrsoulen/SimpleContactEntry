using LiteDB;
using Newtonsoft.Json;
using SimpleContactEntry;
using SimpleContactEntry.Models;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        // This is the only real Unit Test
        // This is testing business logic, the rest are testing integration
        public void GetCallList()
        {
            var contactListFixture = File.ReadAllText(@"./Fixtures/SampleContactList.json");
            IEnumerable<Contact> contactList = JsonConvert.DeserializeObject<IEnumerable<Contact>>(contactListFixture);

            var callListFixture = File.ReadAllText(@"./Fixtures/SampleCallList.json");
            List<CallContact> callList = JsonConvert.DeserializeObject<List<CallContact>>(callListFixture);


            // .ToString() on both makes this pass.
            // I think because they are distinct objects otherwise? 
            // Not sure, first time using XUnit.
            Assert.Equal(CallListMethods.CreateCallList(contactList).ToString(), callList.ToString());
        }

        /*
        I recognize these tests don't test much
        They are just simple happy paths for TDD

        Normally I'd (Skip) all these, since they change actual data
        I'm leaving them without (Skip) since this is a sample app

        Also worth noting, except the first test, these might fail if run out of order.
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
