using System;
using Newtonsoft.Json;

namespace DynamicTags.Models
{
    public partial class EventGridResponse
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("eventTime")]
        public DateTime EventTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("dataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("metadataVersion")]
        public string MetadataVersion { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
