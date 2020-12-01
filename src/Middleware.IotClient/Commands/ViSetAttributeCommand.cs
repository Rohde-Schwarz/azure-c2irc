// <copyright file="ViSetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Client implementation of the ViSetAttribute command.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    public class ViSetAttributeCommand<T> : ViCommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>, IViSetAttributeCommand<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViSetAttributeCommand{T}"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViSetAttributeCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

#pragma warning disable SA1402 // File may only contain a single type

    /// <summary>
    /// Client implementation of the ViSetAttributeByte command.
    /// </summary>
    [Command(Name = "ViSetAttributeByte")]
    public class ViSetAttributeByteCommand : ViSetAttributeCommand<byte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViSetAttributeByteCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViSetAttributeByteCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

    /// <summary>
    /// Client implementation of the ViSetAttributeInt16 command.
    /// </summary>
    [Command(Name = "ViSetAttributeInt16")]
    public class ViSetAttributeInt16Command : ViSetAttributeCommand<short>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViSetAttributeInt16Command"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViSetAttributeInt16Command(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

    /// <summary>
    /// Client implementation of the ViSetAttributeInt32 command.
    /// </summary>
    [Command(Name = "ViSetAttributeInt32")]
    public class ViSetAttributeInt32Command : ViSetAttributeCommand<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViSetAttributeInt32Command"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViSetAttributeInt32Command(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

#pragma warning restore SA1402 // File may only contain a single type
}
