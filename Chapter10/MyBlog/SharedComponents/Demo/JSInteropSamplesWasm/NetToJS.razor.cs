using System.Runtime.InteropServices.JavaScript;
namespace SharedComponents.Demo.JSInteropSamplesWasm;
public partial class NetToJS
{
    [JSImport("showAlert", "nettojs")]
    internal static partial string ShowAlert(string message);
}
