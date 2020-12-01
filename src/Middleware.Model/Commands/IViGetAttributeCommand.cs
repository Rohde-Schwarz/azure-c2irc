// <copyright file="IViGetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Definition for the ViGetAttributeCommand.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    public interface IViGetAttributeCommand<T> : ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>
    {
    }
}
