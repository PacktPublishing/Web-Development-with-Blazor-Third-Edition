using Microsoft.AspNetCore.Components;
using RootLevelCascadingValueDemo.Client;
using RootLevelCascadingValueDemo.Client.Pages;
using RootLevelCascadingValueDemo.Components;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddCascadingValue<Preferences>(sp =>
{
    var preferences = new Preferences { DarkTheme = true };
    var source = new CascadingValueSource<Preferences>("Preferences", preferences, isFixed: false);

    if (preferences is INotifyPropertyChanged changed)
        changed.PropertyChanged += (sender, args) => source.NotifyChangedAsync();

    return source;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
