using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UploadImages.Model;
using UploadImages.Common;

namespace UploadImages
{
    public static class UpLoadTrigger_Input_Binding
    {
        [FunctionName("UpLoadTrigger_Input_Binding")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] BlobViewModel req,
            [Blob("sample-container/sample-blob.png", FileAccess.Write), StorageAccount("AzureWebJobsStorage")] ICollector<Stream> blobContent,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            #region »ñÈ¡Í¼Æ¬Á÷
            var response = FeatchPictureClient.GetWebResponse(req.FilePath);
            var bytes = FeatchPictureClient.GetResponseStream(response);
            await using var memoryStream = new MemoryStream(bytes);
            #endregion

            blobContent.Add(memoryStream);
            return new OkObjectResult("ok");
        }
    }
}
