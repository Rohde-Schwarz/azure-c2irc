// <copyright file="ViReadRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViRead command.
    /// </summary>
    public class ViReadRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets the number of bytes to read.
        /// </summary>
        public int Count { get; set; }
    }
}
