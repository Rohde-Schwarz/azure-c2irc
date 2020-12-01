// <copyright file="ViOpenResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViOpen command.
    /// </summary>
    public class ViOpenResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets the pointer for the opened session.
        /// </summary>
        public int Session { get; set; }
    }
}
