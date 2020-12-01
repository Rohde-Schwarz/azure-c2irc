// <copyright file="ViWriteCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViWriteCommand.
    /// </summary>
    [Command(Name = "ViWrite")]
    internal class ViWriteCommand : ViCommand<ViWriteRequest, ViWriteResponse>, IViWriteCommand
    {
        /// <inheritdoc/>
        public override Task<ViWriteResponse> Invoke(ViWriteRequest request)
        {
            return Task.Run(() =>
            {
                var status = NativeMethods.viWrite(request.Session, request.Buffer, request.Count, out int returnCount);
                return new ViWriteResponse { Request = request, Status = status, ReturnCount = returnCount };
            });
        }
    }
}
