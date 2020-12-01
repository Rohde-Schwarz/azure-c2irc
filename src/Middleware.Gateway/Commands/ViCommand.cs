// <copyright file="ViCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Abstract command class for all gateway commands which has a IRequest
    /// and IResponse.
    /// </summary>
    /// <typeparam name="TRequest">Type of the request object.</typeparam>
    /// <typeparam name="TResponse">Type of the response object.</typeparam>
    internal abstract class ViCommand<TRequest, TResponse> :
        ICommand<TRequest, TResponse>, IGatewayCommand
        where TRequest : IRequest
        where TResponse : IResponse
    {
        /// <summary>
        /// The method to be implemented that processes the request and returns
        /// a response.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        public abstract Task<TResponse> Invoke(TRequest request);

        /// <inheritdoc/>
        public async Task<MethodResponse> Invoke(MethodRequest request) =>
            new MethodResponse(await this.InvokeAsync(request.Data), 200);

        /// <summary>
        /// Method which deserilizes the request, calls the abstract Invoke
        /// method and serializes the response.
        /// </summary>
        /// <param name="request">The request as bytes.</param>
        /// <returns>The response as bytes.</returns>
        private async Task<byte[]> InvokeAsync(byte[] request)
        {
            var strRequest = Encoding.UTF8.GetString(request);  // bytes to string
            var objRequest = JsonConvert.DeserializeObject<TRequest>(strRequest); // string to object
            TResponse objResponse = await this.Invoke(objRequest); // invoke
            var strResponse = JsonConvert.SerializeObject(objResponse); // response to string
            return Encoding.UTF8.GetBytes(strResponse); // string to bytes
        }
    }
}
