// <copyright file="CommandVisa.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Text;
using RohdeSchwarz.Iot.Middleware.Model.Commands;
using RohdeSchwarz.Iot.Middleware.Model.Messages;
using ViAttr = System.Int32;
using ViStatus = System.Int32;

#pragma warning disable SA1121 // Use built-in type alias

namespace RohdeSchwarz.Iot.Middleware.Model
{
    /// <summary>
    /// Abstraction of the message based VISA interface.
    /// </summary>
    public abstract class CommandVisa : IVisa
    {
        /// <summary>
        /// Gets the ViOpenDefaultRMCommand.
        /// </summary>
        protected abstract IViOpenDefaultRMCommand ViOpenDefaultRMCommand { get; }

        /// <summary>
        /// Gets the ViFindRsrcCommand.
        /// </summary>
        protected abstract IViFindRsrcCommand ViFindRsrcCommand { get; }

        /// <summary>
        /// Gets the ViFindNextCommand.
        /// </summary>
        protected abstract IViFindNextCommand ViFindNextCommand { get; }

        /// <summary>
        /// Gets the ViParseRsrcCommand.
        /// </summary>
        protected abstract IViParseRsrcCommand ViParseRsrcCommand { get; }

        /// <summary>
        /// Gets the ViParseRsrcExCommand.
        /// </summary>
        protected abstract IViParseRsrcExCommand ViParseRsrcExCommand { get; }

        /// <summary>
        /// Gets the ViOpenCommand.
        /// </summary>
        protected abstract IViOpenCommand ViOpenCommand { get; }

        /// <summary>
        /// Gets the ViCloseCommand.
        /// </summary>
        protected abstract IViCloseCommand ViCloseCommand { get; }

        /// <summary>
        /// Gets the ViGetAttributeByteCommand.
        /// </summary>
        protected abstract IViGetAttributeCommand<byte> ViGetAttributeByteCommand { get; }

        /// <summary>
        /// Gets the ViGetAttributeInt16Command.
        /// </summary>
        protected abstract IViGetAttributeCommand<short> ViGetAttributeInt16Command { get; }

        /// <summary>
        /// Gets the ViGetAttributeInt32Command.
        /// </summary>
        protected abstract IViGetAttributeCommand<int> ViGetAttributeInt32Command { get; }

        /// <summary>
        /// Gets the ViGetAttributeStringCommand.
        /// </summary>
        protected abstract IViGetAttributeCommand<string> ViGetAttributeStringCommand { get; }

        /// <summary>
        /// Gets the ViSetAttributeByteCommand.
        /// </summary>
        protected abstract IViSetAttributeCommand<byte> ViSetAttributeByteCommand { get; }

        /// <summary>
        /// Gets the ViSetAttributeInt16Command.
        /// </summary>
        protected abstract IViSetAttributeCommand<short> ViSetAttributeInt16Command { get; }

        /// <summary>
        /// Gets the ViSetAttributeInt32Command.
        /// </summary>
        protected abstract IViSetAttributeCommand<int> ViSetAttributeInt32Command { get; }

        /// <summary>
        /// Gets the ViReadCommand.
        /// </summary>
        protected abstract IViReadCommand ViReadCommand { get; }

        /// <summary>
        /// Gets the ViWriteCommand.
        /// </summary>
        protected abstract IViWriteCommand ViWriteCommand { get; }

        /// <inheritdoc/>
        public ViStatus ViOpenDefaultRM(out int sesn)
        {
            var response = this.ViOpenDefaultRMCommand.Invoke(new ViOpenDefaultRMRequest()).GetAwaiter().GetResult();
            sesn = response.Session;
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViFindRsrc(int sesn, string expr, out int vi, out int retCount, StringBuilder desc)
        {
            var response = this.ViFindRsrcCommand.Invoke(new ViFindRsrcRequest() { Session = sesn, Expression = expr }).GetAwaiter().GetResult();
            vi = response.Session;
            retCount = response.Count;
            desc.Append(response.Description);
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViFindNext(int vi, StringBuilder desc)
        {
            var response = this.ViFindNextCommand.Invoke(new ViFindNextRequest() { Session = vi }).GetAwaiter().GetResult();
            desc.Append(response.Description);
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViParseRsrc(int sesn, string desc, out ushort intfType, out ushort intfNum)
        {
            var response = this.ViParseRsrcCommand.Invoke(new ViParseRsrcRequest() { Session = sesn, Description = desc }).GetAwaiter().GetResult();
            intfType = response.InterfaceType;
            intfNum = response.InterfaceNumber;
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViParseRsrcEx(int sesn, string desc, out ushort intfType, out ushort intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists)
        {
            var response = this.ViParseRsrcExCommand.Invoke(new ViParseRsrcExRequest() { Session = sesn, Description = desc }).GetAwaiter().GetResult();
            intfType = response.InterfaceType;
            intfNum = response.InterfaceNumber;
            rsrcClass.Append(response.ResourceClass);
            expandedUnaliasedName.Append(response.ExpandedUnaliasedName);
            aliasIfExists.Append(response.AliasIfExists);
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViOpen(int sesn, string viDesc, int mode, int timeout, out int vi)
        {
            var response = this.ViOpenCommand.Invoke(new ViOpenRequest()
            {
                Session = sesn,
                Description = viDesc,
                Mode = mode,
                Timeout = timeout,
            }).GetAwaiter().GetResult();
            vi = response.Session;
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViClose(int vi)
        {
            var response = this.ViCloseCommand.Invoke(new ViCloseRequest() { Session = vi }).GetAwaiter().GetResult();
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViGetAttribute<T>(int vi, ViAttr attrName, out T attrValue)
        {
            ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>> command;
            attrValue = default;
            switch (attrValue)
            {
                case byte _:
                    command = this.ViGetAttributeByteCommand as ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>;
                    break;
                case short _:
                    command = this.ViGetAttributeInt16Command as ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>;
                    break;
                case int _:
                    command = this.ViGetAttributeInt32Command as ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>;
                    break;
                case string _:
                    command = this.ViGetAttributeStringCommand as ICommand<ViGetAttributeRequest, ViGetAttributeResponse<T>>;
                    break;
                default:
                    throw new ArgumentException($"ViGetAttribute cannot handle Type {typeof(T)}, please use byte, short or int");
            }

            var response = command.Invoke(new ViGetAttributeRequest { Session = vi, AttributeName = attrName }).GetAwaiter().GetResult();
            attrValue = response.AttributeValue;
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViSetAttribute<T>(int vi, ViAttr attrName, T attrValue)
        {
            ICommand<ViSetAttributeRequest<T>, ViSetAttributeResponse> command;
            switch (attrValue)
            {
                case byte _:
                    command = this.ViSetAttributeByteCommand as ICommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>;
                    break;
                case short _:
                    command = this.ViSetAttributeInt16Command as ICommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>;
                    break;
                case int _:
                    command = this.ViSetAttributeInt32Command as ICommand<ViSetAttributeRequest<T>, ViSetAttributeResponse>;
                    break;
                default:
                    throw new ArgumentException($"ViSetAttribute cannot handle Type {typeof(T)}, please use byte, short or int");
            }

            var response = command.Invoke(new ViSetAttributeRequest<T> { Session = vi, AttributeName = attrName, AttributeValue = attrValue }).GetAwaiter().GetResult();
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViRead(int vi, byte[] buffer, int count, out int retCount)
        {
            var response = this.ViReadCommand.Invoke(new ViReadRequest() { Session = vi, Count = count }).GetAwaiter().GetResult();
            retCount = response.ReturnCount;
            Array.Copy(response.Buffer, buffer, retCount);
            return response.Status;
        }

        /// <inheritdoc/>
        public ViStatus ViWrite(int vi, byte[] buffer, int count, out int retCount)
        {
            var response = this.ViWriteCommand.Invoke(new ViWriteRequest() { Session = vi, Buffer = buffer, Count = count }).GetAwaiter().GetResult();
            retCount = response.ReturnCount;
            return response.Status;
        }
    }
}

#pragma warning restore SA1121 // Use built-in type alias