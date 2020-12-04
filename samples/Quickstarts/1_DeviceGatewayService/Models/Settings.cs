namespace DeviceGatewayService.Models
{
    /// <summary>
    /// Class that represents the settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The IoT Hub settings.
        /// </summary>
        public HubSettings Hub { get; set; } = new HubSettings();

        /// <summary>
        /// The internet proxy settings.
        /// </summary>
        public ProxySettings Proxy { get; set; } = new ProxySettings();

        /// <summary>
        /// Class that represents the settings for the IoT Hub.
        /// </summary>
        public class HubSettings
        {
            /// <summary>
            /// The address of the IoT Hub.
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// The shared access key for the IoT Hub.
            /// </summary>
            public string SharedAccessKey { get; set; }

            /// <summary>
            /// The device id of the gateway.
            /// </summary>
            public string DeviceId { get; set; }
        }

        /// <summary>
        /// Class that represents the settings for the internet proxy.
        /// </summary>
        public class ProxySettings
        {
            /// <summary>
            /// <see langword="true" /> if the proxy is enabled; otherwise, <see langword="false" />.
            /// </summary>
            public bool Enabled { get; set; }

            /// <summary>
            /// The URI of the proxy server.
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// <see langword="true" /> to bypass the proxy for local addresses; otherwise, <see langword="false" />.
            /// </summary>
            public bool BypassOnLocal { get; set; }

            /// <summary>
            /// The settings for the proxy credentials.
            /// </summary>
            public CredentialsSettings Credentials { get; set; } = new CredentialsSettings();

            /// <summary>
            /// Class that represents the credentials for the proxy.
            /// </summary>
            public class CredentialsSettings
            {
                /// <summary>
                /// <see langword="true" /> if the proxy is an authentication proxy; otherwise, <see langword="false" />.
                /// </summary>
                public bool Enabled { get; set; }

                /// <summary>
                /// The user name associated with the credentials.
                /// </summary>
                public string User { get; set; }

                /// <summary>
                /// The password for the user name associated with the credentials.
                /// </summary>
                public string Password { get; set; }
            }
        }
    }
}
