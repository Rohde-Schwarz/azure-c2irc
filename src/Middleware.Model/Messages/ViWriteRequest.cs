// <copyright file="ViWriteRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViWrite command.
    /// </summary>
    public class ViWriteRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets the data to write.
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        /// Gets or sets the length of the data to write.
        /// </summary>
        public int Count { get; set; }
    }
}
