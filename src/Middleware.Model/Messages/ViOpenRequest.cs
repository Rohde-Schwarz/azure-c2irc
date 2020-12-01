// <copyright file="ViOpenRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViOpen command.
    /// </summary>
    public class ViOpenRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets the connection string e.g. TCPIP::127.0.0.1::INSTR.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        public int Mode { get; set; }

        /// <summary>
        /// Gets or sets the timeout for connection.
        /// </summary>
        public int Timeout { get; set; }
    }
}
