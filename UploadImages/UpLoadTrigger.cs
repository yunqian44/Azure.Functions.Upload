using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;
using UploadImages.Service;
using UploadImages.Model;

namespace UploadImages
{
    public class UpLoadTrigger
    {
        private readonly IBlobService _blobSergvice;

        public UpLoadTrigger(IBlobService blobSergvice)
        {
            _blobSergvice = blobSergvice;
        }

        [FunctionName("UpLoadTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] BlobViewModel req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //var content = await new StreamReader(req.Body).ReadToEndAsync();
            //string filePath = req.Query["filePath"];
            //string fileName = req.Query["fileName"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            await _blobSergvice.UploadContentBlobAsync(req.FileContent, req.FileName);

            //await _blobSergvice.UploadContentBlobAsync(req.FilePath, req.FileName);
            return new OkObjectResult("ok");
        }
    }
}
