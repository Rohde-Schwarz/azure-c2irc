using DeviceGatewayService.Models;
using DeviceGatewayService.Utils;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RohdeSchwarz.Iot.Middleware.Gateway;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceGatewayService.Workers
{
    /// <summary>
    /// Background service to handle incomming method invokations from the IoT Hub.
    /// </summary>
    public class VisaBackgroundService : IHostedService
    {
        private readonly ILogger<VisaBackgroundService> _logger;

        private DeviceClient _deviceClient;

        /// <summary>
        /// The current connection status.
        /// </summary>
        public string ConnectionStatus { get; set; } = "Not Connected";

        public VisaBackgroundService(ILogger<VisaBackgroundService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken _)
        {
            var settings = SettingsFactory.Load();

            if (settings.Hub.Address != null && settings.Hub.DeviceId != null && settings.Hub.SharedAccessKey != null)
            {
                try
                {
                    _deviceClient = DeviceClient.Create(settings.Hub.Address,
                        new DeviceAuthenticationWithRegistrySymmetricKey(
                            settings.Hub.DeviceId,
                            settings.Hub.SharedAccessKey
                        ),
                        new ITransportSettings[] {
                            new AmqpTransportSettings(TransportType.Amqp_WebSocket_Only) {
                                Proxy = ProxyHelper.GetWebProxy(settings.Proxy)
                            }
                        });

                    _deviceClient.SetRetryPolicy(new ExponentialBackoff(16, TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100)));

                    _deviceClient.SetConnectionStatusChangesHandler((status, reason) => {
                        ConnectionStatus = status.ToString();
                        _logger.LogDebug("DeviceClient Connection Status changed to: " + status.ToString() + " (Reason: " + reason.ToString() + ")");
                    });

                    _logger.LogDebug($"Connecting Device {settings.Hub.DeviceId} to Hub {settings.Hub.Address} ...");

                    await GatewayController.Initialize(_deviceClient);

                    _logger.LogDebug("Connection to Hub established.");
                } catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
                
            }
            else
            {
                _logger.LogError("Missing hub configuration.");
            }
        }


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task StopAsync(CancellationToken _)

        {
            _deviceClient?.Dispose();
            _logger.LogDebug("Connection to Hub stoped.");
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
