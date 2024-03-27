export async function setMessage() {
    const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
    var exports = await getAssemblyExports("BlazorWebAssembly.Client.dll");
    alert(exports.BlazorWebAssembly.Client.JSInteropSamples.JSToStaticNET.GetAMessageFromNET());
}

export async function showMessage() {
    await setMessage();
}

