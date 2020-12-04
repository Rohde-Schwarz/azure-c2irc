using DeviceGatewayService.Models;
using DeviceGatewayService.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceGatewayService.Controllers
{
    /// <summary>
    /// The controller for the Settings page.
    /// </summary>
    public class SettingsController : Controller
    {

        private readonly ILogger<SettingsController> _logger;

        private readonly VisaBackgroundService _visaWorker;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="logger">Injected logger.</param>
        /// <param name="visaWorker">Injected Visa Service</param>
        public SettingsController(ILogger<SettingsController> logger,
            VisaBackgroundService visaWorker)
        {
            _logger = logger;
            _visaWorker = visaWorker;
        }

        public IActionResult Index()
        {
            var model = SettingsFactory.Load();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Settings model)
        {
            if (ModelState.IsValid)
            {
                SettingsFactory.Save(model);
                _logger.LogInformation("Settings saved.");

                var cToken = new CancellationToken();

                await _visaWorker.StopAsync(cToken);
                await _visaWorker.StartAsync(cToken);
            }
            return View(model);
        }
    }
}