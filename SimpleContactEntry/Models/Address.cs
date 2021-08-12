using System.Text.Json.Serialization;

namespace SimpleContactEntry
{
    public class Address
    {

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }
    }
}
