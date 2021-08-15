using Newtonsoft.Json;

namespace SimpleContactEntry.Models
{
    public class CallContact
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
