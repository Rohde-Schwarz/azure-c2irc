// <copyright file="ViFindRsrcResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViFindRsrc command.
    /// </summary>
    public class ViFindRsrcResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets a handle identifying this search session.
        /// </summary>
        public int Session { get; set; }

        /// <summary>
        /// Gets or sets number of matches.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets a string identifying the location of a device.
        /// </summary>
        public string Description { get; set; }
    }
}
