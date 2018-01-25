using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags.Models
{
    public partial class ResourceWriteSuccess
    {
        [JsonProperty("authorization")]
        public EvtAuthorization Authorization { get; set; }

        [JsonProperty("claims")]
        public Dictionary<string, string> Claims { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

        [JsonProperty("httpRequest")]
        public EvtHttpRequest HttpRequest { get; set; }

        [JsonProperty("resourceProvider")]
        public string ResourceProvider { get; set; }

        [JsonProperty("resourceUri")]
        public string ResourceUri { get; set; }

        [JsonProperty("operationName")]
        public string OperationName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }
    }
}
