// <copyright file="ViFindNextCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Text;
using System.Threading.Tasks;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Gateway implementation of the ViFindNextCommand.
    /// </summary>
    [Command(Name = "ViFindNext")]
    internal class ViFindNextCommand : ViCommand<ViFindNextRequest, ViFindNextResponse>, IViFindNextCommand
    {
        /// <inheritdoc/>
        public override Task<ViFindNextResponse> Invoke(ViFindNextRequest request)
        {
            return Task.Run(() =>
            {
                var sb = new StringBuilder(1024);
                var status = NativeMethods.viFindNext(request.Session, sb);
                return new ViFindNextResponse { Request = request, Status = status, Description = sb.ToString() };
            });
        }
    }
}
