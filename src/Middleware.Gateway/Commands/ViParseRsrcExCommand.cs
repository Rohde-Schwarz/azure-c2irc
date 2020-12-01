// <copyright file="ViParseRsrcExCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
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
    /// Gateway implementation of the ViParseRsrcExCommand.
    /// </summary>
    [Command(Name = "ViParseRsrcEx")]
    internal class ViParseRsrcExCommand : ViCommand<ViParseRsrcExRequest, ViParseRsrcExResponse>, IViParseRsrcExCommand
    {
        /// <inheritdoc/>
        public override Task<ViParseRsrcExResponse> Invoke(ViParseRsrcExRequest request)
        {
            return Task.Run(() =>
            {
                var rsrcClass = new StringBuilder(1024);
                var expandedUnaliasedName = new StringBuilder(1024);
                var aliasIfExists = new StringBuilder(1024);
                var status = NativeMethods.viParseRsrcEx(request.Session, request.Description, out short intfType, out short intfNum, rsrcClass, expandedUnaliasedName, aliasIfExists);
                return new ViParseRsrcExResponse
                {
                    Request = request, Status = status, InterfaceType = (ushort)intfType, InterfaceNumber = (ushort)intfNum,
                    ResourceClass = rsrcClass.ToString(), ExpandedUnaliasedName = expandedUnaliasedName.ToString(), AliasIfExists = aliasIfExists.ToString(),
                };
            });
        }
    }
}
