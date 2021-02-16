using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    var dirs = Directory.GetDirectories(drive.ToString());
                    foreach (var  dri in dirs )
                    {
                       
                        Console.WriteLine(dri);
                    }
                   
                }

                    await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
