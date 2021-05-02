//
// ConfigurationPathAttribute.cs
//
// Author:
//       Craig Fowler <craig@craigfowler.me.uk>
//
// Copyright (c) 2017 Craig Fowler
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace CSF.Configuration
{
    /// <summary>
    /// Attribute used to indicate the path (in a configuration file) where this class is found.
    /// </summary>
    /// <remarks>
    /// <para>
    /// By default, configuration types are found at a path based upon their namespace.  This attributes permits
    /// overriding that and specifying an alternative path.
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ConfigurationPathAttribute : Attribute
    {
        /// <summary>
        /// Gets the configuration path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSF.Configuration.ConfigurationPathAttribute"/> class.
        /// </summary>
        /// <param name="path">Path.</param>
        public ConfigurationPathAttribute(string path)
        {
            if(path == null)
                throw new ArgumentNullException(nameof(path));
            if(path.Length == 0)
                throw new FormatException(Resources.ExceptionMessages.PathStringMustNotBeEmpty);

            Path = path;
        }
    }
}

