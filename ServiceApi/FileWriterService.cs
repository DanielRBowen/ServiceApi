using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceApi
{
    public class FileWriterService : IHostedService, IDisposable
    {
        private const string Path = @"c:\TestApplication.txt";

        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            _timer = new Timer(
                (e) => WriteTimeToFile(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public void WriteTimeToFile()
        {
            if (!File.Exists(Path))
            {
                using (var sw = File.CreateText(Path))
                {
                    sw.WriteLine(DateTime.UtcNow.ToString("O"));
                }
            }
            else
            {
                using (var sw = File.AppendText(Path))
                {
                    sw.WriteLine(DateTime.UtcNow.ToString("O"));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
