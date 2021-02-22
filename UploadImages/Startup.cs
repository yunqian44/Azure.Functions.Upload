using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using UploadImages;
using UploadImages.Common;
using UploadImages.Service;

[assembly: FunctionsStartup(typeof(Startup))]

namespace UploadImages
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(new Appsettings(builder.GetContext().ApplicationRootPath));
            builder.Services.AddSingleton(x => new BlobServiceClient(Appsettings.app("AzureBlobStorageConnectionString")));

            //builder.Services.AddSingleton(x => new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=cnbatestorageaccount;AccountKey=EsEUMqoZbqwrqXrtQcVGPL1p5FHFReIyObRAnVdZfCXXXXXXXXXXXXXXX3Eh4O/5NvfhDB0BF9C74osmnkagRWQ==;EndpointSuffix=core.windows.net"));
            builder.Services.AddTransient<IBlobService, BlobService>();
        }
    }
}
