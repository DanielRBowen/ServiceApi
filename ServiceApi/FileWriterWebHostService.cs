using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System;
using System.Threading.Tasks;

namespace ServiceApi
{
    public class FileWriterWebHostService : WebHostService, IDisposable
    {
        private static readonly FileWriterService _fileWriterService = new FileWriterService();
        public FileWriterWebHostService(IWebHost host) : base(host)
        {

        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            Task.Run(() => _fileWriterService.StartAsync());
        }

        protected override void OnStopping()
        {
            base.OnStopping();
            Task.Run(() => _fileWriterService.StopAsync());
        }
    }
}
