// <copyright file="ViWriteResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViWrite command.
    /// </summary>
    public class ViWriteResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets the number of bytes written.
        /// </summary>
        public int ReturnCount { get; set; }
    }
}
