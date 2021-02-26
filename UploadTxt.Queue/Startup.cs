using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UploadTxt.Queue;
using UploadTxt.Queue.Common;

[assembly: FunctionsStartup(typeof(Startup))]

namespace UploadTxt.Queue
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddSingleton(new Appsettings(builder.GetContext().ApplicationRootPath));
        }
    }
}
