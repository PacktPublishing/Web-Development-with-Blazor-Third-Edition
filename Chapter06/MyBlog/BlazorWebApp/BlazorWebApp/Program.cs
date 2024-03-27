using Data;
using Data.Models.Interfaces;
using BlazorWebApp.Client.Pages;
using BlazorWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddOptions<BlogApiJsonDirectAccessSetting>().Configure(options =>
{
    options.DataPath = @"..\..\..\..\Data\";
    options.BlogPostsFolder = "Blogposts";
    options.TagsFolder = "Tags";
    options.CategoriesFolder = "Categories";
    options.CommentsFolder = "Comments";
});

builder.Services.AddScoped<IBlogApi, BlogApiJsonDirectAccess>();

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
    .AddAdditionalAssemblies(typeof(Counter).Assembly)
    .AddAdditionalAssemblies(typeof(SharedComponents.Pages.Home).Assembly);

app.Run();
