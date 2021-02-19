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

            await _blobSergvice.UploadImagesBlobAsync(req.FilePath, req.FileName);
            return new OkObjectResult("ok");
        }
    }
}
