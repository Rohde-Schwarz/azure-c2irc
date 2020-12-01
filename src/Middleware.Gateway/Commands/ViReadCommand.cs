// <copyright file="ViReadCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViReadCommand.
    /// </summary>
    [Command(Name = "ViRead")]
    internal class ViReadCommand : ViCommand<ViReadRequest, ViReadResponse>, IViReadCommand
    {
        /// <inheritdoc/>
        public override Task<ViReadResponse> Invoke(ViReadRequest request)
        {
            return Task.Run(() =>
            {
                var buffer = new byte[request.Count];
                var status = NativeMethods.viRead(request.Session, buffer, request.Count, out int returnCount);
                return new ViReadResponse { Request = request, Status = status, Buffer = buffer, ReturnCount = returnCount };
            });
        }
    }
}
