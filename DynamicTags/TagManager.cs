
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Dynamic;
using Microsoft.CSharp;
using DynamicTags.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

namespace DynamicTags
{
    public static class TagManager
    {
        [FunctionName("TagManager")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                IList<EventGridResponse> data = JsonConvert.DeserializeObject<IList<EventGridResponse>>(requestBody);

                if (data.Count == 1 && data[0].EventType == EventType.SubscriptionValidationEvent)
                {
                    return new OkObjectResult(GetValidationResponse((string)data[0].Data.validationCode));
                }

                foreach (EventGridResponse response in data)
                {
                    ResourceWriteSuccess evt = JsonConvert.DeserializeObject<ResourceWriteSuccess>(JsonConvert.SerializeObject(response.Data));
                    ProcessEvent.Process(evt);
                    log.Info(String.Format("Processed subscription event with data:\r\n{0}", requestBody));
                }

                return new OkResult();
            }
            catch (Exception ex)
            {
                log.Error("Error processing event", ex);
                return new OkResult();
            }
        }

        private static dynamic GetValidationResponse(string key)
        {
            dynamic res = new ExpandoObject();
            res.validationResponse = key;
            return res;
        }
    }
}
