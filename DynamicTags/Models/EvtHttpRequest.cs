using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags.Models
{
    public class EvtHttpRequest
    {
        [JsonProperty("clientRequestId")]
        public string ClientRequestId { get; set; }

        [JsonProperty("clientIpAddress")]
        public string ClientIpAddress { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
