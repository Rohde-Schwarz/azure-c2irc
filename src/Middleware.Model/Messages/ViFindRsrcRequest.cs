// <copyright file="ViFindRsrcRequest.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the request for the ViFindRsrc command.
    /// </summary>
    public class ViFindRsrcRequest : ViRequest
    {
        /// <summary>
        /// Gets or sets the pattern for the search function.
        /// </summary>
        public string Expression { get; set; }
    }
}
