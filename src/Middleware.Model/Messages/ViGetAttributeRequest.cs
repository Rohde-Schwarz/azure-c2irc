// <copyright file="ViGetAttributeRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViGetAttribute command.
    /// </summary>
    public class ViGetAttributeRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets session, event, or find list attribute for which the state
        /// query is made.
        /// </summary>
        public int AttributeName { get; set; }
    }
}
