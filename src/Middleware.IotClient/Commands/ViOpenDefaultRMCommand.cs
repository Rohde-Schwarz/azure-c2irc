// <copyright file="ViOpenDefaultRMCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Client implementation of the ViOpenDefaultRM command.
    /// </summary>
    [Command(Name = "ViOpenDefaultRM")]
    public class ViOpenDefaultRMCommand : ViCommand<ViOpenDefaultRMRequest, ViOpenDefaultRMResponse>, IViOpenDefaultRMCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViOpenDefaultRMCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViOpenDefaultRMCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }
}
