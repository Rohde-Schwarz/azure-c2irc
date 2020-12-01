// <copyright file="ViParseRsrcResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViParseRsrc command.
    /// </summary>
    public class ViParseRsrcResponse : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets interface type of the given resource string.
        /// </summary>
        public ushort InterfaceType { get; set; }

        /// <summary>
        /// Gets or sets board number of the interface of the given resource string.
        /// </summary>
        public ushort InterfaceNumber { get; set; }
    }
}
