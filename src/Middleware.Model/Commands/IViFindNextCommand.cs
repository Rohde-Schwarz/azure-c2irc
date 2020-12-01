// <copyright file="IViFindNextCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Definition for the ViFindNext command.
    /// </summary>
    public interface IViFindNextCommand : ICommand<ViFindNextRequest, ViFindNextResponse>
    {
    }
}
