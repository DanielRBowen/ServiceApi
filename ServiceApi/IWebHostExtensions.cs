using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace ServiceApi
{
    public static class IWebHostExtensions
    {
        public static void RunAsFileWriterWebHostService(this IWebHost host)
        {
            var webHostService = new FileWriterWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
}
