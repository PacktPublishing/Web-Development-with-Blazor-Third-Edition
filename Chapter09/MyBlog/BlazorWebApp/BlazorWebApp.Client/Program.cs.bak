using BlazorWebApp.Client;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient("Public",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient("Authenticated", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddTransient<IBlogApi, BlogApiWebClient>();
await builder.Build().RunAsync();
