using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SimpleContactEntry
{
    public class Phone
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        [RegularExpression("mobile|home|work", ErrorMessage = "Phone number type must be \"home\", \"work\" or \"mobile\".")]
        public string Type { get; set; }
    }
}
