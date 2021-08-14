using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SimpleContactEntry
{
    public class Contact
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phone")]
        public List<Phone> Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
