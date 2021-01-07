using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GestionStocks
{
    public static class Negotiate
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Run(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [SignalRConnectionInfo(ConnectionStringSetting = "AzureSignalRConnectionString", HubName = "stocks")]SignalRConnectionInfo  connectionInfo,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return connectionInfo;
        }
    }
}
