using MemesConstructorClient.Interfaces;
using MemesConstructorClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace MemesConstructorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddFileReaderService(options =>
            {
                options.UseWasmSharedBuffer = true;
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44309/") });

            builder.Services.AddScoped<IMemesService, MemesService>();

            await builder.Build().RunAsync();
        }
    }
}
