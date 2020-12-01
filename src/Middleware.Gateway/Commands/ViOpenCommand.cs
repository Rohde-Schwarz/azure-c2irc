// <copyright file="ViOpenCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViOpenCommand.
    /// </summary>
    [Command(Name = "ViOpen")]
    internal class ViOpenCommand : ViCommand<ViOpenRequest, ViOpenResponse>, IViOpenCommand
    {
        /// <inheritdoc/>
        public override Task<ViOpenResponse> Invoke(ViOpenRequest request)
        {
            return Task.Run(() =>
            {
                var status = NativeMethods.viOpen(request.Session, request.Description, request.Mode, request.Timeout, out int session);
                return new ViOpenResponse { Request = request, Status = status, Session = session };
            });
        }
    }
}
