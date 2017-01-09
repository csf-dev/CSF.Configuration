//
// ConfigurationReader.cs
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
using System.Configuration;
using System.Reflection;

namespace CSF.Configuration
{
  /// <summary>
  /// Default implementation of <see cref="IConfigurationReader"/> which uses the <c>ConfigurationManager</c>.
  /// </summary>
  public class ConfigurationReader : IConfigurationReader
  {
    #region methods

    /// <summary>
    /// Gets a type that represents a <see cref="ConfigurationSection"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method uses the default configuration path, retrieved using
    /// <see cref="M:GetDefaultConfigurationPath{TSection}"/>.
    /// </para>
    /// <para>
    /// If the section is not found at the appropriate configuration path, or if the configuration section found at that
    /// path is not of the requested type then a <c>null</c> reference is returned instead.
    /// </para>
    /// </remarks>
    /// <returns>
    /// The section, or a <c>null</c> reference.
    /// </returns>
    /// <typeparam name='TSection'>
    /// The type of configuration section to retrieve.
    /// </typeparam>
    public TSection GetSection<TSection>() where TSection : ConfigurationSection
    {
      string sectionPath = GetDefaultConfigurationPath<TSection>();
      return GetSection<TSection>(sectionPath);
    }

    /// <summary>
    /// Gets a type that represents a <see cref="ConfigurationSection"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method uses a user-supplied path within the configuration file.
    /// </para>
    /// <para>
    /// If the section is not found at the appropriate configuration path, or if the configuration section found at that
    /// path is not of the requested type then a <c>null</c> reference is returned instead.
    /// </para>
    /// </remarks>
    /// <returns>
    /// The section, or a <c>null</c> reference.
    /// </returns>
    /// <param name='path'>
    /// The path (in the configuration file) to the desired section.
    /// </param>
    /// <typeparam name='TSection'>
    /// The type of configuration section to retrieve.
    /// </typeparam>
    public TSection GetSection<TSection>(string path) where TSection : ConfigurationSection
    {
      object configObject = ConfigurationManager.GetSection(path);
      return configObject as TSection;
    }

    /// <summary>
    /// Gets the default configuration path for a type that implements <see cref="ConfigurationSection"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For configuration sections decorated with <see cref="ConfigurationPathAttribute"/>, this method returns the
    /// path specified in the attribute.
    /// </para>
    /// <para>
    /// For all other types, the return value is equivalent to the full name of the specified type, substituting the
    /// period <c>'.'</c> character with a forward-slash character <c>'/'</c>
    /// </para>
    /// </remarks>
    /// <returns>
    /// The default path (in the configuration file) to the specified section.
    /// </returns>
    /// <typeparam name='TSection'>
    /// The type of configuration section for which we want to generate a default path.
    /// </typeparam>
    public string GetDefaultConfigurationPath<TSection>() where TSection : ConfigurationSection
    {
      var type = typeof(TSection);

      var pathAttribute = type.GetCustomAttribute<ConfigurationPathAttribute>();
      if(pathAttribute != null)
      {
        return pathAttribute.Path;
      }

      return type.FullName.Replace('.', '/');
    }

    #endregion
  }
}

