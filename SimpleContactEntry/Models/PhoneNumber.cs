using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleContactEntry
{
    public class Phone
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("type")]
        [RegularExpression("mobile|home|work", ErrorMessage = "Phone number type must be \"home\", \"work\" or \"mobile\".")]
        public string Type { get; set; }
    }
}
