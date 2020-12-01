// <copyright file="ViParseRsrcRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViParseRsrc command.
    /// </summary>
    public class ViParseRsrcRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets unique symbolic name of a resource.
        /// </summary>
        public string Description { get; set; }
    }
}
