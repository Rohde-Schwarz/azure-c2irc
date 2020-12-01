// <copyright file="GatewayController.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;
using RohdeSchwarz.Iot.Middleware.Gateway.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway
{
    /// <summary>
    /// A static service that is handling the remote methods.
    /// </summary>
    public static class GatewayController
    {
        /// <summary>
        /// The logger for the gateway.
        /// </summary>
        private static ILogger log;

        /// <summary>
        /// Sets a logger for the gateway.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public static void SetLogger(ILogger logger) => log = logger;

        /// <summary>
        /// Initializes the gateway and sets the method handlers.
        /// </summary>
        /// <param name="deviceClient">The configured device client.</param>
        /// <returns>The task for async function.</returns>
        public static async Task Initialize(DeviceClient deviceClient)
        {
            var taskList = new List<Task>();
            var commands = Command.GetTypesWithCommandAttribute(typeof(GatewayController).Assembly);
            foreach (var command in commands)
            {
                MemberInfo memberInfo = command;
                foreach (var attribute in memberInfo.GetCustomAttributes())
                {
                    if (attribute is Command commandAttribute)
                    {
                        taskList.Add(deviceClient.SetMethodHandlerAsync(
                            commandAttribute.Name,
                            (MethodRequest methodRequest, object userContext) =>
                            {
                                log?.LogInformation($"Command {commandAttribute.Name} called.");
                                return (Activator.CreateInstance(command) as IGatewayCommand).Invoke(methodRequest);
                            },
                            null));
                    }
                }
            }

            await Task.WhenAll(taskList);
        }
    }
}
