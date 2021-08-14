using Newtonsoft.Json;

namespace SimpleContactEntry
{
    public class Name
    {

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }        
    }
}
