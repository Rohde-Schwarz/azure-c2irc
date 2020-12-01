﻿// <copyright file="IViWriteCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Commands
{
    using RohdeSchwarz.Iot.Middleware.Model.Messages;

    /// <summary>
    /// Definition for the ViWrite command.
    /// </summary>
    public interface IViWriteCommand : ICommand<ViWriteRequest, ViWriteResponse>
    {
    }
}
