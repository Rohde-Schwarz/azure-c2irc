// <copyright file="ViSetAttributeRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViSetAttribute command.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    public class ViSetAttributeRequest<T> : ViRequest
    {
        /// <summary>
        /// Gets or sets session, event, or find list attribute for which the state is modified.
        /// </summary>
        public int AttributeName { get; set; }

        /// <summary>
        /// Gets or sets the state of the attribute to be set for the specified
        /// resource. The interpretation of the individual attribute
        /// value is defined by the resource.
        /// </summary>
        public T AttributeValue { get; set; }
    }
}
