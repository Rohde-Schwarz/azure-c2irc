// <copyright file="ViGetAttributeCommand.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Text;
using System.Threading.Tasks;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway.Commands
{
    /// <summary>
    /// Gateway implementation of the ViGetAttributeCommand.
    /// </summary>
    /// <typeparam name="T">Attribute type.</typeparam>
    internal class ViGetAttributeCommand<T> : ViCommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>, IViGetAttributeCommand<T>
    {
        /// <inheritdoc/>
        public override Task<ViGetAttributeResponse<T>> Invoke(ViGetAttributeRequest request)
        {
            return Task.Run(() =>
            {
                T output = default;
                int status = default;
                status = output switch
                {
                    byte b => NativeMethods.viGetAttribute(request.Session, request.AttributeName, out b),
                    short s => NativeMethods.viGetAttribute(request.Session, request.AttributeName, out s),
                    int i => NativeMethods.viGetAttribute(request.Session, request.AttributeName, out i),
                    StringBuilder sb => NativeMethods.viGetAttribute(request.Session, request.AttributeName, sb),
                    _ => throw new ArgumentException($"ViGetAttribute cannot handle Type {typeof(T)}, please use byte, short, int or StringBuilder"),
                };
                return new ViGetAttributeResponse<T> { Request = request, Status = status, AttributeValue = output };
            });
        }
    }

    /// <summary>
    /// Gateway implementation of the ViGetAttributeByteCommand.
    /// </summary>
    [Command(Name = "ViGetAttributeByte")]
    internal class ViGetAttributeByteCommand : ViGetAttributeCommand<byte>
    {
    }

    /// <summary>
    /// Gateway implementation of the ViGetAttributeInt16Command.
    /// </summary>
    [Command(Name = "ViGetAttributeInt16")]
    internal class ViGetAttributeInt16Command : ViGetAttributeCommand<short>
    {
    }

    /// <summary>
    /// Gateway implementation of the ViGetAttributeInt32Command.
    /// </summary>
    [Command(Name = "ViGetAttributeInt32")]
    internal class ViGetAttributeInt32Command : ViGetAttributeCommand<int>
    {
    }

    /// <summary>
    /// Gateway implementation of the ViGetAttributeStringCommand.
    /// </summary>
    [Command(Name = "ViGetAttributeString")]
    internal class ViGetAttributeStringCommand : ViGetAttributeCommand<string>
    {
    }
}
