using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HostedConsoleApp
{
    internal class TestService : IHostedService
    {
        private readonly ILogger<TestService> _logger;
        private bool looper = false;
        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
            looper = true;
            _logger.LogInformation("Started Test Service");

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                while (looper)
                {
                    _logger.LogInformation("Test Service Running");
                    Thread.Sleep(1000);
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            looper = false;
            _logger.LogInformation("Stopping Test Service");

            return Task.CompletedTask;
        }
    }
}