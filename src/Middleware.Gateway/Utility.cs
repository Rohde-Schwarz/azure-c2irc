// <copyright file="Utility.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RohdeSchwarz.Iot.Middleware.Gateway.Internal;
using RohdeSchwarz.Iot.Middleware.Model;
using RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes;

namespace RohdeSchwarz.Iot.Middleware.Gateway
{
    /// <summary>
    /// Utility class.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Returns a list of all implemented commands on the gateway.
        /// </summary>
        /// <returns>List of implemented commands.</returns>
        public static IEnumerable<string> GetSupportedCommands()
            => from command in Command.GetTypesWithCommandAttribute(typeof(GatewayController).Assembly)
               select (from attr in (command as MemberInfo).GetCustomAttributes()
                       where attr is Command
                       select attr as Command).FirstOrDefault().Name;

        /// <summary>
        /// Returns the manufacturer and the version of the installed Visa.
        /// </summary>
        /// <returns>Touple of manufacturer and version.</returns>
        public static (string manufacturer, string version) GetVisaManufacturerAndVersion()
        {
            try
            {
                NativeMethods.viOpenDefaultRM(out int session);
                StringBuilder manufacturerStringBuilder = new StringBuilder();
                NativeMethods.viGetAttribute(session, (int)ViAttributes.VI_ATTR_RSRC_MANF_NAME, manufacturerStringBuilder);
                NativeMethods.viGetAttribute(session, (int)ViAttributes.VI_ATTR_RSRC_IMPL_VERSION, out int version);
                NativeMethods.viClose(session);
                var ver = new Version(version >> 20, (version & 0xFFF00) >> 8, version & 0xFF);
                return (manufacturerStringBuilder.ToString(), ver.ToString());
            }
            catch (DllNotFoundException)
            {
                return ("not installed", "not installed");
            }
        }
    }
}
