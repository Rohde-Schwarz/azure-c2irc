// <copyright file="ViCloseCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Gateway implementation of the ViCloseCommand.
    /// </summary>
    [Command(Name = "ViClose")]
    internal class ViCloseCommand : ViCommand<ViCloseRequest, ViCloseResponse>, IViCloseCommand
    {
        /// <inheritdoc/>
        public override Task<ViCloseResponse> Invoke(ViCloseRequest request)
        {
            return Task.Run(() =>
            {
                var status = NativeMethods.viClose(request.Session);
                return new ViCloseResponse { Request = request, Status = status };
            });
        }
    }
}
