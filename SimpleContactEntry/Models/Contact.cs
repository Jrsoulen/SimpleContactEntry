using Newtonsoft.Json;
using System.Collections.Generic;

namespace SimpleContactEntry
{
    public class Contact
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
