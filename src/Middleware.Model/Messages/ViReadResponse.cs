// <copyright file="ViReadResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViRead command.
    /// </summary>
    public class ViReadResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets the readed data.
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        /// Gets or sets the length of the readed data.
        /// </summary>
        public int ReturnCount { get; set; }
    }
}
