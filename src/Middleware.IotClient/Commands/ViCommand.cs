// <copyright file="ViCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.IotClient.Commands
{
    /// <summary>
    /// Abstract class for command implementations in the client.
    /// </summary>
    /// <typeparam name="TRequest">Type of the request object.</typeparam>
    /// <typeparam name="TResponse">Type of the response object.</typeparam>
    public abstract class ViCommand<TRequest, TResponse> : ICommand<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
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
        /// Initializes a new instance of the <see cref="ViCommand{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="serviceClient">The IoT Hub Service client.</param>
        /// <param name="deviceId">The device id of the gateway.</param>
        public ViCommand(ServiceClient serviceClient, string deviceId)
        {
            this.serviceClient = serviceClient;
            this.deviceId = deviceId;
        }

        /// <summary>
        /// Gets or sets the timeout for the method invokation.
        /// </summary>
        public TimeSpan ResponseTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Invokes the method in the IoT Hub for the given device.
        /// </summary>
        /// <param name="request">The method request.</param>
        /// <returns>The method response.</returns>
        public async Task<TResponse> Invoke(TRequest request)
        {
            var strRequest = JsonConvert.SerializeObject(request);
            var strResponse = await this.Invoke(strRequest);
            return JsonConvert.DeserializeObject<TResponse>(strResponse);
        }

        /// <summary>
        /// Invokes the method in the IoT Hub for the given device.
        /// </summary>
        /// <param name="request">The method request as string.</param>
        /// <returns>The method response as string.</returns>
        public async Task<string> Invoke(string request)
        {
            var methodName = (this.GetType().GetCustomAttributes(typeof(Command), true)[0] as Command).Name;
            var methodInvocation = new CloudToDeviceMethod(methodName)
            {
                ResponseTimeout = this.ResponseTimeout,
            };
            methodInvocation.SetPayloadJson(request);

            var response = await this.serviceClient.InvokeDeviceMethodAsync(this.deviceId, methodInvocation);
            return response.GetPayloadAsJson();
        }
    }
}
