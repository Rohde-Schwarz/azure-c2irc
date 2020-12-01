// <copyright file="Command.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

namespace RohdeSchwarz.Iot.Middleware.Model.Reflection.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Attribute to Tag Commands for the Middleware.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class Command : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the Command e.g. ViWrite.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns all types who are tages with the command attribute.
        /// </summary>
        /// <param name="assembly">The application assembly.</param>
        /// <returns>List of command types.</returns>
        public static IEnumerable<Type> GetTypesWithCommandAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(Command), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
