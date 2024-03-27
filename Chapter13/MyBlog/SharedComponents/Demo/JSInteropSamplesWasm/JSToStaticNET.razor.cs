using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
namespace SharedComponents.Demo.JSInteropSamplesWasm;

[SupportedOSPlatform("browser")]
public partial class JSToStaticNET
{
    [JSExport]
    internal static string GetAMessageFromNET()
    {
        return "This is a message from .NET";
    }

    [JSImport("showMessage", "jstonet")]
    internal static partial void ShowMessage();
}
