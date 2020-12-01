// <copyright file="IotVisa.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using Microsoft.Azure.Devices;
using RohdeSchwarz.Iot.Middleware.IotClient.Commands;
using RohdeSchwarz.Iot.Middleware.Model;
using RohdeSchwarz.Iot.Middleware.Model.Commands;

namespace RohdeSchwarz.Iot.Middleware.Client
{
    /// <summary>
    /// VISA implementation for the client.
    /// </summary>
    public class IotVisa : CommandVisa
    {
        /// <summary>
        /// The IoT Hub Service client.
        /// </summary>
        private readonly ServiceClient serviceClient;

        /// <summary>
        /// The device id of the gateway.
        /// </summary>
        private readonly string deviceId;

        /// <summary>
        /// Initializes a new instance of the <see cref="IotVisa"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public IotVisa(ServiceClient serviceClient, string deviceId)
        {
            this.serviceClient = serviceClient;
            this.deviceId = deviceId;
        }

        /// <inheritdoc/>
        protected override IViCloseCommand ViCloseCommand => new ViCloseCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViOpenCommand ViOpenCommand => new ViOpenCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViOpenDefaultRMCommand ViOpenDefaultRMCommand => new ViOpenDefaultRMCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViFindRsrcCommand ViFindRsrcCommand => new ViFindRsrcCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViFindNextCommand ViFindNextCommand => new ViFindNextCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViParseRsrcCommand ViParseRsrcCommand => new ViParseRsrcCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViParseRsrcExCommand ViParseRsrcExCommand => new ViParseRsrcExCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViGetAttributeCommand<byte> ViGetAttributeByteCommand => new ViGetAttributeByteCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViGetAttributeCommand<short> ViGetAttributeInt16Command => new ViGetAttributeInt16Command(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViGetAttributeCommand<int> ViGetAttributeInt32Command => new ViGetAttributeInt32Command(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViGetAttributeCommand<string> ViGetAttributeStringCommand => new ViGetAttributeStringCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViSetAttributeCommand<byte> ViSetAttributeByteCommand => new ViSetAttributeByteCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViSetAttributeCommand<short> ViSetAttributeInt16Command => new ViSetAttributeInt16Command(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViSetAttributeCommand<int> ViSetAttributeInt32Command => new ViSetAttributeInt32Command(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViReadCommand ViReadCommand => new ViReadCommand(this.serviceClient, this.deviceId);

        /// <inheritdoc/>
        protected override IViWriteCommand ViWriteCommand => new ViWriteCommand(this.serviceClient, this.deviceId);
    }
}
