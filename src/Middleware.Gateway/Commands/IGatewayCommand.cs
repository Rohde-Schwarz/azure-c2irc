// <copyright file="IGatewayCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// The interface for all commands in the gateway.
    /// </summary>
    internal interface IGatewayCommand
    {
        /// <summary>
        /// Method which will be takes as a method handler for the device client.
        /// </summary>
        /// <param name="request">The method request from the device client.</param>
        /// <returns>The method response for the device client.</returns>
        Task<MethodResponse> Invoke(MethodRequest request);
    }
}
