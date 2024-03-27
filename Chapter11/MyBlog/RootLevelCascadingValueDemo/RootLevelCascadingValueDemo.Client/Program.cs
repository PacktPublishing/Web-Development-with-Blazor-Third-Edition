using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RootLevelCascadingValueDemo.Client;
using System.ComponentModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddCascadingValue<Preferences>(sp =>
{
    var preferences = new Preferences { DarkTheme = true };
    var source = new CascadingValueSource<Preferences>("Preferences", preferences, isFixed: false);

    if (preferences is INotifyPropertyChanged changed)
        changed.PropertyChanged += (sender, args) => source.NotifyChangedAsync();

    return source;
});


await builder.Build().RunAsync();
