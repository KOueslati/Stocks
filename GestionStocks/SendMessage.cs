using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace GestionStocks
{
    public static class SendMessage
    {
        [FunctionName("SendMessage")]
        public static Task Run([CosmosDBTrigger(
            databaseName: "stocksdb",
            collectionName: "stocks",
            ConnectionStringSetting = "AzureCosmosDBConnectionString",
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true,
            FeedPollDelay = 500)] IReadOnlyList<Document> documents,
            ILogger log,
            [SignalR(ConnectionStringSetting = "AzureSignalRConnectionString", HubName = "stocks")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            log.LogInformation("C# CosmosDB trigger function.");

            return signalRMessages.AddAsync(new SignalRMessage()
            {
                Target = "updated",
                Arguments = new []{ documents[0]}
            });
        }
    }
}
