using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags.Models
{
    public class EvtEvidence
    {
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}
