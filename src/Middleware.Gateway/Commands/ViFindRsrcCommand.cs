// <copyright file="ViFindRsrcCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViFindRsrcCommand.
    /// </summary>
    [Command(Name = "ViFindRsrc")]
    internal class ViFindRsrcCommand : ViCommand<ViFindRsrcRequest, ViFindRsrcResponse>, IViFindRsrcCommand
    {
        /// <inheritdoc/>
        public override Task<ViFindRsrcResponse> Invoke(ViFindRsrcRequest request)
        {
            return Task.Run(() =>
            {
                var sb = new StringBuilder(1024);
                var status = NativeMethods.viFindRsrc(request.Session, request.Expression, out int vi, out int retCount, sb);
                return new ViFindRsrcResponse { Request = request, Status = status, Session = vi, Count = retCount, Description = sb.ToString() };
            });
        }
    }
}
