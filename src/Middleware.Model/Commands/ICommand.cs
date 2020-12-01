// <copyright file="ICommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using System.Threading.Tasks;
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Interface to define a command.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request (function parameters). Must be Json serializable.</typeparam>
    /// <typeparam name="TResponse">The type of the response (return values). Must be Json serializable.</typeparam>
    public interface ICommand<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        /// <summary>
        /// The method to invoke the command.
        /// </summary>
        /// <param name="request">Object with function parameters.</param>
        /// <returns>Object with return values.</returns>
        Task<TResponse> Invoke(TRequest request);
    }
}
