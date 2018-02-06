using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Data;
using System.Threading.Tasks;
using TableStorage;
using DynamicTags.Models;
using System.Security.Claims;

namespace DynamicTags
{
    public static class LogTable
    {
        public static async Task Write(ResourceWriteSuccess evt)
        {
            string tableName = "logTable";
            try
            {
                CloudTable table = await Common.CreateTableAsync(tableName);
                LogItem item = new LogItem(evt.SubscriptionId, evt.Claims[ClaimTypes.Name])
                {
                    ActionDate = DateTime.UtcNow,
                    IpAddress = evt.HttpRequest.ClientIpAddress,
                    OperationName = evt.OperationName,
                    ResourceName = evt.ResourceUri,
                    Status = evt.Status
                };

                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(item);

                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);

                LogItem insertedEvent = result.Result as LogItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
