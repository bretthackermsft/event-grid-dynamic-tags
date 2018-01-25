using Newtonsoft.Json;
namespace DynamicTags.Models
{
    public class SubscriptionValidationEvent
    {
        [JsonProperty("validationCode")]
        public string ValidationCode { get; set; }
    }
}
