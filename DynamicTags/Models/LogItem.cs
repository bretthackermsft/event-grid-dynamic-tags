using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags.Models
{
    public class LogItem : TableEntity
    {
        public LogItem()
        {

        }
        public LogItem(string subscriptionId, string userName)
        {
            PartitionKey = subscriptionId;
            RowKey = userName;
        }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("actionDate")]
        public DateTime ActionDate { get; set; }

        [JsonProperty("resourceName")]
        public string ResourceName { get; set; }

        [JsonProperty("operationName")]
        public string OperationName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
