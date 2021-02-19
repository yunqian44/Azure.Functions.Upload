using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UploadImages;
using UploadImages.Service;

[assembly: FunctionsStartup(typeof(Startup))]

namespace UploadImages
{
    public class Startup : FunctionsStartup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddSingleton(x => new BlobServiceClient("storageaccount_connection"));
            builder.Services.AddSingleton(x => new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=cnbatestorageaccount;AccountKey=EsEUMqoZbqwrqXrtQcVGPL1p5FHFReIyObRAnVdZfCXXXXXXXXXXXXXXX3Eh4O/5NvfhDB0BF9C74osmnkagRWQ==;EndpointSuffix=core.windows.net"));
            builder.Services.AddTransient<IBlobService, BlobService>();
        }
    }
}
