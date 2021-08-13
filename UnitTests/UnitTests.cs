using Newtonsoft.Json;
using SimpleContactEntry;
using System;
using System.IO;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        //[Fact(Skip = "Integration Test")]
        [Fact]
        public void CreateNewContact()
        {
            var json = File.ReadAllText(@"./Fixtures/SampleContact.json");
            Contact contact = JsonConvert.DeserializeObject<Contact>(json);

            LiteDBRepo dBRepo = new LiteDBRepo();
            dBRepo.CreateContact(contact);
        }

        [Fact]
        public void CreateNewAddress()
        {
            var json = File.ReadAllText(@"./Fixtures/SampleAddress.json");
            Address contact = JsonConvert.DeserializeObject<Address>(json);
        }
    }
}
