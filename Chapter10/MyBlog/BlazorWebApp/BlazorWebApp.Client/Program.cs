using BlazorApp1.Client;
using BlazorWebApp.Client;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();


builder.Services.AddHttpClient("Api",client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddTransient<IBlogApi, BlogApiWebClient>();
await builder.Build().RunAsync();
