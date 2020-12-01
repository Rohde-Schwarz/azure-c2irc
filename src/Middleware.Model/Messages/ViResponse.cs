// <copyright file="ViResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The base class for all Visa responses.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public class ViResponse<TRequest> : IResponse
         where TRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the request with which the command is initialized.
        /// </summary>
        public TRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the return status of the Visa function.
        /// </summary>
        public int Status { get; set; }
    }
}
