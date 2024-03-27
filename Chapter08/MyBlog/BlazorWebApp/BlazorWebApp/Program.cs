using Data;
using Data.Models.Interfaces;
using BlazorWebApp.Client.Pages;
using BlazorWebApp.Components;
using BlazorWebApp.Endpoints;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWebApp;


var builder = WebApplication.CreateBuilder(args);
//This is so I don't accidentally check in my local appsettings.json file
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

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

builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();

builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Authority"] ?? ""; ;
        options.ClientId = builder.Configuration["Auth0:ClientId"] ?? ""; ;
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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly)
    .AddAdditionalAssemblies(typeof(SharedComponents.Pages.Home).Assembly);
app.MapBlogPostApi();
app.MapCategoryApi();
app.MapTagApi();
app.MapCommentApi();


app.MapGet("Account/Login", async (string returnUrl, HttpContext context) =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
         .WithRedirectUri(returnUrl)
         .Build();
    await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("authentication/logout", async (HttpContext context) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
         .WithRedirectUri("/")
         .Build();
    await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});



app.Run();
