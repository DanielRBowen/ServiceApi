using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ServiceApi;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sv.Client.Service
{
    public class Program
    {
        /// <summary>
        /// Some of the code is from: https://www.stevejgordon.co.uk/running-net-core-generic-host-applications-as-a-windows-service
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
            }

            var builder = CreateWebHostBuilder(
                args.Where(arg => arg != "--console").ToArray());

            var host = builder.Build();

            if (isService)
            {
                host.RunAsFileWriterWebHostService();
            }
            else
            {
                var storeViewHubService = new FileWriterService();
                await storeViewHubService.StartAsync();
                host.Run();
                Console.WriteLine("Service Started");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:50380")
                .UseStartup<Startup>();
    }
}
