// <copyright file="ViOpenDefaultRMResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViOpenDefaultRM command.
    /// </summary>
    public class ViOpenDefaultRMResponse : ViResponse<ViOpenDefaultRMRequest>
    {
        /// <summary>
        /// Gets or sets the session pointer for the RM.
        /// </summary>
        public int Session { get; set; }
    }
}
