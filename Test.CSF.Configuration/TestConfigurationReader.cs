//
// TestConfigurationReader.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2015 CSF Software Limited
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
using NUnit.Framework;
using CSF.Configuration;

namespace Test.CSF.Configuration
{
  [TestFixture]
  public class TestConfigurationReader
  {
    #region fields

    private IConfigurationReader _sut;

    #endregion

    #region setup

    [SetUp]
    public void Setup()
    {
      _sut = new ConfigurationReader();
    }

    #endregion

    #region tests

    [Test]
    public void GetDefaultSectionPath_returns_default_path_based_on_namespace_when_no_attribute_present()
    {
      string path = _sut.GetDefaultSectionPath<MockConfigurationSection>();
      Assert.AreEqual("Test/CSF/Configuration/MockConfigurationSection", path);
    }

    [Test]
    public void GetDefaultSectionPath_returns_specified_path_when_attribute_is_present()
    {
      string path = _sut.GetDefaultSectionPath<MockConfigurationSectionWithExplicitPath>();
      Assert.AreEqual("foo/bar/baz", path);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_default_path_returns_instance_when_present_in_config_file()
    {
      var result = _sut.ReadSection<MockConfigurationSection>();
      Assert.IsNotNull(result);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_default_path_returns_instance_with_correct_data()
    {
      var result = _sut.ReadSection<MockConfigurationSection>();
      Assert.AreEqual("Configured value", result.MockProperty);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_attribute_path_returns_instance_when_present_in_config_file()
    {
      var result = _sut.ReadSection<MockConfigurationSectionWithExplicitPath>();
      Assert.IsNotNull(result);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_attribute_path_returns_instance_with_correct_data()
    {
      var result = _sut.ReadSection<MockConfigurationSectionWithExplicitPath>();
      Assert.AreEqual("One", result.MockProperty);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_specified_path_returns_instance_when_present_in_config_file()
    {
      var result = _sut.ReadSection<AnotherMockConfigurationSectionWithExplicitPath>("foo/bar/wibble");
      Assert.IsNotNull(result);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_specified_path_returns_instance_with_correct_data()
    {
      var result = _sut.ReadSection<AnotherMockConfigurationSectionWithExplicitPath>("foo/bar/wibble");
      Assert.AreEqual("Two", result.MockProperty);
    }

    [Test]
    [Description("This test depends upon data in the unit test config file")]
    public void ReadSection_with_nonexistent_path_returns_null()
    {
      var result = _sut.ReadSection<AnotherMockConfigurationSectionWithExplicitPath>("does/not/exist");
      Assert.IsNull(result);
    }

    #endregion
  }
}

