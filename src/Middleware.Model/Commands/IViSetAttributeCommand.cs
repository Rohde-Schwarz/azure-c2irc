// <copyright file="IViSetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Definition for the ViSetAttribute command.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    public interface IViSetAttributeCommand<T> : ICommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>
    {
    }
}
