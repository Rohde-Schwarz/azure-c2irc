// <copyright file="ViGetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Client implementation of the ViGetAttribute command.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    public class ViGetAttributeCommand<T> : ViCommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>, IViGetAttributeCommand<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViGetAttributeCommand{T}"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViGetAttributeCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

#pragma warning disable SA1402 // File may only contain a single type

    /// <summary>
    /// Client implementation of the ViGetAttributeByte command.
    /// </summary>
    [Command(Name = "ViGetAttributeByte")]
    public class ViGetAttributeByteCommand : ViGetAttributeCommand<byte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViGetAttributeByteCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViGetAttributeByteCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

    /// <summary>
    /// Client implementation of the ViGetAttributeInt16 command.
    /// </summary>
    [Command(Name = "ViGetAttributeInt16")]
    public class ViGetAttributeInt16Command : ViGetAttributeCommand<short>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViGetAttributeInt16Command"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViGetAttributeInt16Command(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

    /// <summary>
    /// Client implementation of the ViGetAttributeInt32 command.
    /// </summary>
    [Command(Name = "ViGetAttributeInt32")]
    public class ViGetAttributeInt32Command : ViGetAttributeCommand<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViGetAttributeInt32Command"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViGetAttributeInt32Command(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

    /// <summary>
    /// Client implementation of the ViGetAttributeString command.
    /// </summary>
    [Command(Name = "ViGetAttributeString")]
    public class ViGetAttributeStringCommand : ViGetAttributeCommand<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViGetAttributeStringCommand"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViGetAttributeStringCommand(ServiceClient serviceClient, string deviceId)
            : base(serviceClient, deviceId)
        {
        }
    }

#pragma warning restore SA1402 // File may only contain a single type
}
