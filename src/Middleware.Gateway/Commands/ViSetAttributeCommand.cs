// <copyright file="ViSetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Gateway implementation of the ViSetAttributeCommand.
    /// </summary>
    /// <typeparam name="T">Type of attribute.</typeparam>
    internal class ViSetAttributeCommand<T> : ViCommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>, IViSetAttributeCommand<T>
    {
        /// <inheritdoc/>
        public override Task<ViSetAttributeResponse> Invoke(ViSetAttributeRequest<T> request)
        {
            return Task.Run(() =>
            {
                int status = default;
                switch (request.AttributeValue)
                {
                    case byte b:
                        status = NativeMethods.viSetAttribute(request.Session, request.AttributeName, b);
                        break;
                    case short s:
                        status = NativeMethods.viSetAttribute(request.Session, request.AttributeName, s);
                        break;
                    case int i:
                        status = NativeMethods.viSetAttribute(request.Session, request.AttributeName, i);
                        break;
                    default:
                        throw new ArgumentException($"ViSetAttribute cannot handle Type {typeof(T)}, please use byte, short, int");
                }

                return new ViSetAttributeResponse { Request = request, Status = status };
            });
        }
    }

    /// <summary>
    /// Gateway implementation of the ViSetAttributeByteCommand.
    /// </summary>
    [Command(Name = "ViSetAttributeByte")]
    internal class ViSetAttributeByteCommand : ViSetAttributeCommand<byte>
    {
    }

    /// <summary>
    /// Gateway implementation of the ViSetAttributeInt16Command.
    /// </summary>
    [Command(Name = "ViSetAttributeInt16")]
    internal class ViSetAttributeInt16Command : ViSetAttributeCommand<short>
    {
    }

    /// <summary>
    /// Gateway implementation of the ViSetAttributeInt32Command.
    /// </summary>
    [Command(Name = "ViSetAttributeInt32")]
    internal class ViSetAttributeInt32Command : ViSetAttributeCommand<int>
    {
    }
}
