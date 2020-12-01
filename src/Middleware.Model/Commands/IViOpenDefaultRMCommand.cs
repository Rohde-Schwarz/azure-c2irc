// <copyright file="IViOpenDefaultRMCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Definition for the ViOpenDefualRM command.
    /// </summary>
    public interface IViOpenDefaultRMCommand : ICommand<ViOpenDefaultRMRequest, ViOpenDefaultRMResponse>
    {
    }
}
