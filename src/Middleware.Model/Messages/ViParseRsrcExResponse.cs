// <copyright file="ViParseRsrcExResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViParseRsrcEx command.
    /// </summary>
    public class ViParseRsrcExResponse : ViParseRsrcResponse
    {
        /// <summary>
        /// Gets or sets the resource class (for example, “INSTR”) of the given resource string.
        /// </summary>
        public string ResourceClass { get; set; }

        /// <summary>
        /// Gets or sets the expanded version of the given resource string.
        /// </summary>
        public string ExpandedUnaliasedName { get; set; }

        /// <summary>
        /// Gets or sets the user-defined alias for the given resource string.
        /// </summary>
        public string AliasIfExists { get; set; }
    }
}
