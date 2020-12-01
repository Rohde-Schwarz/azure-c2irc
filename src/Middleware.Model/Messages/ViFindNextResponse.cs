// <copyright file="ViFindNextResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViFindNext command.
    /// </summary>
    public class ViFindNextResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets a string identifying the location of a device.
        /// </summary>
        public string Description { get; set; }
    }
}
