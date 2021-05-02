# Abstraction for ConfigurationManager

This very small library provides the interface `CSF.Configuration.IConfigurationReader`.
This is an abstraction around `System.Configuration.ConfigurationManager`, either from .NET Framework FCL
or [the NuGet package](https://www.nuget.org/packages/System.Configuration.ConfigurationManager).

It is provided to read objects that implement `ConfigurationSection` from your configuration file.

_It is expected that version 1.2 of this library will be the last.  .NET is moving away from XML configuration files in favour of JSON.  `ConfigurationManager` is a legacy API now and whilst it is still supported, it is not favoured for new development._

## Usage

Create an instance of `CSF.Configuration.ConfigurationReader` and consume it in your logic via the interface.
Here is a demonstration of usage.

### Configuration section

```csharp
namespace Sample.Namespace
{
    public class MyConfigSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(SampleProperty))]
        public string SampleProperty
        {
            get => (string) this[nameof(SampleProperty)];
            set => this[nameof(SampleProperty)] = value;
        }
    }
}
```

### Configuration file

```xml
<?xml version="1.0"?>
<configuration>
    <configSections>
        <sectionGroup name="Sample">
            <sectionGroup name="Namespace">
                <section name="MyConfigSection"
                         type="Sample.Namespace.MyConfigSection, My.Assembly.Name" />
            </sectionGroup>
        </sectionGroup>
    </configSections>
    <Sample>
        <Namespace>
            <MyConfigSection SampleProperty="Configured value" />
        </Namespace>
    </Sample>
</configuration>
```

### Consumer

```csharp
// Or dependency-inject a CSF.Configuration.IConfigurationReader
var reader = new CSF.Configuration.ConfigurationReader();
var myConfig = reader.ReadSection<Sample.Namespace.MyConfigSection>();
```

## Configuration paths & customisation

By default, the path within the configuration file to find a section is based upon its fully qualified namespace name.
In the example above the configuration section is named `Sample.Namespace.MyConfigSection`.
The path used by default is thus `Sample/Namespace/MyConfigSection`.

This path may be explicitly provided at the point of consumption if desired, via an overload of the `ReadSection` method which takes a string.
Alternatively, you may decorate your configuration section class with the `[ConfigurationPath("custom/XML/path")]` attribute, which declares a different/explicit default path for reading that section.

## Open source license
All source files within this project are released as open source software,
under the terms of [the MIT license].

[the MIT license]: http://opensource.org/licenses/MIT

This software is distributed in the hope that it will be useful, but please
remember that:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.