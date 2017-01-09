# Configuration helper
This library introduces an interface `IConfigurationReader` and a default implementation `ConfigurationReader`.
This very simple service provides a way to avoid some of the boilerplate code when getting a `System.Configuration.ConfigurationSection` from an XML configuration file.

## Getting a section from its default path
```csharp
IConfigurationReader reader = GetConfigurationReader();

var myConfig = reader.ReadSection<MyConfigurationSection>();
```

By default, the configuration file path queried is based upon namespace-qualified-name of the configuration section.
Periods are replaced with slashes and the result used as the path.
In the following example, the reader would look in the path `Foo/Bar/Baz/MyConfigurationSection`.

```csharp
namespace Foo.Bar.Baz
{
  public class MyConfigurationSection : ConfigurationSection { /* Implementation omitted */ }
}
```

## Specifying the default path in an attribute
You may override the default path at which the reader looks for a configuration section, using an attribute.
In the following example, the reader would look in the path `my/custom/path`, ignoring the namespace and type name.

```csharp
namespace Foo.Bar.Baz
{
  [ConfigurationPath("my/custom/path")]
  public class MyConfigurationSection : ConfigurationSection { /* Implementation omitted */ }
}
```

## Specifying a path
If a string parameter is provided to the `ReadSection<T>` method, then the specified path is used, and neither of the two mechanisms above are used.

## Getting just the default path
Finally, the reader provides a method to get the default path for a section.
This returns either the path specified by an attribute (if it is present), or the path based upon the namespace-qualified-name:

```csharp
var path = reader.GetDefaultSectionPath<MyConfigurationSection>();
```

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