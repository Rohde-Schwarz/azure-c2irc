using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeviceGatewayService.Models;
using RohdeSchwarz.Iot.Middleware.Gateway;
using DeviceGatewayService.Workers;
using System;

namespace DeviceGatewayService.Controllers
{
    /// <summary>
    /// Controler for the Home page.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly VisaBackgroundService _visaWorker;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="visaWorker">Injected Visa Service.</param>
        public HomeController(VisaBackgroundService visaWorker)
        {
            _visaWorker = visaWorker;
        }

        public IActionResult Index()
        {
            var (manufacturer, version) = Utility.GetVisaManufacturerAndVersion();
            ViewData["ManufacturerName"] = manufacturer;
            ViewData["ImplementationVersion"] = version;
            ViewData["OsName"] = Environment.OSVersion.ToString();
            ViewData["SupportedCommands"] = Utility.GetSupportedCommands();
            ViewData["ConnectionStatus"] = _visaWorker.ConnectionStatus;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
