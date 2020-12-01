// <copyright file="ViGetAttributeResponse.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Messages
{
    /// <summary>
    /// The definition of the response for the ViGetAttribute command.
    /// </summary>
    /// <typeparam name="T">Type of the attribute.</typeparam>
    public class ViGetAttributeResponse<T> : ViResponse<ViRequest>
    {
        /// <summary>
        /// Gets or sets the state of the queried attribute for a specified resource.
        /// </summary>
        public T AttributeValue { get; set; }
    }
}
