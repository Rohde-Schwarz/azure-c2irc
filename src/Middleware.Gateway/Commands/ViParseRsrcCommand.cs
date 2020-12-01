// <copyright file="ViParseRsrcCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViParseRsrcCommand.
    /// </summary>
    [Command(Name = "ViParseRsrc")]
    internal class ViParseRsrcCommand : ViCommand<ViParseRsrcRequest, ViParseRsrcResponse>, IViParseRsrcCommand
    {
        /// <inheritdoc/>
        public override Task<ViParseRsrcResponse> Invoke(ViParseRsrcRequest request)
        {
            return Task.Run(() =>
            {
                var status = NativeMethods.viParseRsrc(request.Session, request.Description, out short intfType, out short intfNum);
                return new ViParseRsrcResponse { Request = request, Status = status, InterfaceType = (ushort)intfType, InterfaceNumber = (ushort)intfNum };
            });
        }
    }
}
