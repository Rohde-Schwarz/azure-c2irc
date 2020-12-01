// <copyright file="ViParseRsrcExCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Client implementation of the ViParseRsrcEx command.
    /// </summary>
    [Command(Name = "ViParseRsrcEx")]
    public class ViParseRsrcExCommand : ViCommand<ViParseRsrcExRequest, ViParseRsrcExResponse>, IViParseRsrcExCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViParseRsrcExCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViParseRsrcExCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }
}
