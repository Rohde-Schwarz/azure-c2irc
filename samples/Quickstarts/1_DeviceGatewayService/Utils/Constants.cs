using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceGatewayService.Utils
{
    public static class Constants
    {
        /// <summary>
        /// The path for the local storage off the application.
        /// </summary>
        public static string ApplicationDataPath => Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData,
                Environment.SpecialFolderOption.DoNotVerify),
            typeof(Constants).Assembly.GetName().Name);
    }
}
