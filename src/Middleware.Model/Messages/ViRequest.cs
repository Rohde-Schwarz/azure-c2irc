// <copyright file="ViRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// Base class for all Visa commands which needs a session as input.
    /// Typically all but ViOpenDefaultRM.
    /// </summary>
    public class ViRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the session pointer for the Visa commands.
        /// </summary>
        public int Session { get; set; }
    }
}
