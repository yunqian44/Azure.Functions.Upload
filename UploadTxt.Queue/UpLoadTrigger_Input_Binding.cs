using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace UploadTxt.Queue
{
    public static class UpLoadTrigger_Input_Binding
    {
        [FunctionName("UpLoadTrigger_Input_Binding")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Queue("validationcode"), StorageAccount("AzureWebJobsStorage")] ICollector<string> queue,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string content = "我叫张三。他叫胡歌";
            queue.Add(content);

            return new OkObjectResult("ok");
        }
    }
}
