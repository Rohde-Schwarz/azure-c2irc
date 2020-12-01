// <copyright file="ViFindNextCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Client implementation of the ViFindNext command.
    /// </summary>
    [Command(Name = "ViFindNext")]
    public class ViFindNextCommand : ViCommand<ViFindNextRequest, ViFindNextResponse>, IViFindNextCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViFindNextCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViFindNextCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }
}
