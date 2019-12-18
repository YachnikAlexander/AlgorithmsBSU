using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Host;

namespace MessageWork
{
    public static class Function1
    { 
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var data = "im localy develop azure function and publish on portal";
            if (string.IsNullOrWhiteSpace(data))
            {
                return new BadRequestObjectResult("Please pass an URL on the query string");
            }
            else
            {
                return new OkObjectResult($"{data}");
            }
        }
    }
}


