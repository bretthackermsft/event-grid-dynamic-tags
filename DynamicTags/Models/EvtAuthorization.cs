using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags.Models
{
    public partial class EvtAuthorization
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("evidence")]
        public EvtEvidence Evidence { get; set; }
    }
}
