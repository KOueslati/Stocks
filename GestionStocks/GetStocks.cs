using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GestionStocks
{
    public static class GetStocks
    {
        [FunctionName("getStocks")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest request,
            [CosmosDB("stocksdb","stocks", ConnectionStringSetting = "AzureCosmosDBConnectionString")] IEnumerable<Product> items
            , ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            if (items != null)
            {
                return new OkObjectResult(items);
            }

            return new BadRequestResult();
        }
    }
}
