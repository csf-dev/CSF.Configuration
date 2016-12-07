# Configuration helper
This library introduces the **`ConfigurationHelper`** static class.
It has a few useful methods, which largely function as shortcuts for calls to
`System.Configuration.ConfigurationManager`.

* `GetSection<T>` - gets a typed configuration section

* `GetDefaultConfigurationPath<T>` - gets a default 'path' (in the XML structure) to a section

The concept of a default path simply uses the type's namespaces to determine
where in an XML configuration structure it should exist.
Thus the following configuration type:

```csharp
namespace Sample.Application
{
  public class MyConfig : ConfigurationSection
  {
    // Implementation here
  }
}
```

… would exist at the following location:

```xml
<Sample>
  <Application>
    <MyConfig />
  </Application>
</Sample>
```

The parameterless overload of `GetSection<T>` assumes that the section is
located at that configuration path.
The other overload permits the passing of a string indicating the path.

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