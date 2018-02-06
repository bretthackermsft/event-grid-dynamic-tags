
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Dynamic;
//using System.Configuration;
using Microsoft.CSharp;
using DynamicTags.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
//using TableStorage;
using System.Threading.Tasks;

namespace DynamicTags
{
    public static class TagManager
    {
        [FunctionName("TagManager")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            string requestBody = "";
            try
            {
                requestBody = new StreamReader(req.Body).ReadToEnd();
                IList<EventGridResponse> data = JsonConvert.DeserializeObject<IList<EventGridResponse>>(requestBody);

                if (data.Count == 1 && data[0].EventType == EventType.SubscriptionValidationEvent)
                {
                    log.Info(String.Format("Registering event grid..."));
                    return new OkObjectResult(GetValidationResponse((string)data[0].Data.validationCode));
                }

                foreach (EventGridResponse response in data)
                {
                    response.Data.authorization = JToken.Parse(response.Data.authorization.ToString());
                    response.Data.claims = JToken.Parse(response.Data.claims.ToString());
                    response.Data.httpRequest = JToken.Parse(response.Data.httpRequest.ToString());

                    ResourceWriteSuccess evt = JsonConvert.DeserializeObject<ResourceWriteSuccess>(JsonConvert.SerializeObject(response.Data));
                    var logItem = ProcessEvent.Process(evt);

                    //log.Info(String.Format("Processed subscription event with data:\r\n{0}", requestBody));
                    log.Info(String.Format("New event - log data:\r\n{0}", JsonConvert.SerializeObject(logItem)));
                }

                return new OkResult();
            }
            catch (Exception ex)
            {
                log.Error("Error processing event", ex, requestBody);
                log.Error("Err evt data", null, requestBody);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
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
