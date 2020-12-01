// <copyright file="ViOpenDefaultRMCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Gateway implementation of the ViOpenDefaultRMCommand.
    /// </summary>
    [Command(Name = "ViOpenDefaultRM")]
    internal class ViOpenDefaultRMCommand : ViCommand<ViOpenDefaultRMRequest, ViOpenDefaultRMResponse>, IViOpenDefaultRMCommand
    {
        /// <inheritdoc/>
        public override Task<ViOpenDefaultRMResponse> Invoke(ViOpenDefaultRMRequest request)
        {
            return Task.Run(() =>
            {
                int session = NativeMethods.VI_NULL;
                int status = NativeMethods.VI_NULL;
                status = NativeMethods.viOpenDefaultRM(out session);
                return new ViOpenDefaultRMResponse { Request = request, Status = status, Session = session };
            });
        }
    }
}
