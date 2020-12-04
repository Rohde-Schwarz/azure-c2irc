using DeviceGatewayService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeviceGatewayService.Utils
{
    public static class ProxyHelper
    {
        /// <summary>
        /// Converts the proxy settings to an object of IWebProxy.
        /// </summary>
        /// <param name="proxySettings">The proxy settings object.</param>
        /// <returns>The IWebProxy object.</returns>
        public static IWebProxy GetWebProxy(Settings.ProxySettings proxySettings)
        {
            if (proxySettings != null && proxySettings.Enabled)
            {
                var proxy = new WebProxy(proxySettings.Address, proxySettings.BypassOnLocal);
                if (proxySettings.Credentials != null && proxySettings.Credentials.Enabled)
                    proxy.Credentials = new NetworkCredential(proxySettings.Credentials.User, proxySettings.Credentials.Password);
                return proxy;
            }
            return null;
        }
    }
}
