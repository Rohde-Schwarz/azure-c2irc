using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IoTWebClient.Models;
using RohdeSchwarz.Iot.Middleware.Model;
using RohdeSchwarz.Iot.Middleware.Client;
using Microsoft.Azure.Devices;
using System.Text;

namespace IoTWebClient.Controllers
{
    public class HomeController : Controller
    {
        const string IOT_HUB_CONNECTION_STRING = "<your hub's connection string>"; // e.g. "HostName=Delos-Mesa-Hub.azure-devices.net;SharedAccessKeyName=..."
        const string GATEWAY_DEVICE_ID = "<your gateway's id>"; // e.g. "qa-gateway1"

        private readonly IVisa visa;

        public HomeController()
        {
            visa = new IotVisa(ServiceClient.CreateFromConnectionString(IOT_HUB_CONNECTION_STRING, TransportType.Amqp), GATEWAY_DEVICE_ID);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SendCommandFormModel model)
        {
            var command = model.Command.Trim();

            visa.ViOpenDefaultRM(out int rm);
            visa.ViOpen(rm, model.Connection.Trim(), 0, 1000, out int vi);
            var request = Encoding.UTF8.GetBytes(command);
            visa.ViWrite(vi, request, request.Length, out _);

            if (command.EndsWith('?'))
            {
                byte[] buffer = new byte[1024];
                visa.ViRead(vi, buffer, 1024, out int retCount2);
                var response = Encoding.UTF8.GetString(buffer, 0, retCount2);
                ViewData["Answer"] = "Response: " + response;
            }

            visa.ViClose(vi);
            visa.ViClose(rm);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
