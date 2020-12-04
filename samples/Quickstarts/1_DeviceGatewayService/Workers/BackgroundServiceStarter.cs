using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceGatewayService.Workers
{
    /// <summary>
    /// Service to start/stop background services.
    /// Code from:
    /// https://stackoverflow.com/questions/51254053/how-to-inject-a-reference-to-a-specific-ihostedservice-implementation
    /// </summary>
    public class BackgroundServiceStarter<T> : IHostedService where T : IHostedService
    {
        private readonly T backgroundService;

        public BackgroundServiceStarter(T backgroundService) => this.backgroundService = backgroundService;

        public Task StartAsync(CancellationToken cancellationToken) => backgroundService.StartAsync(cancellationToken);

        public Task StopAsync(CancellationToken cancellationToken) => backgroundService.StopAsync(cancellationToken);
    }
}
