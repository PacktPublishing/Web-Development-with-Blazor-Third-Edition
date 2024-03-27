
using Data.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Data.Tests;

[ExcludeFromCodeCoverage]
public class DataTestFixture : IAsyncLifetime
{
    public IBlogApi Api { get; set; } = default!;

    public async Task InitializeAsync()
    {
        var environment = "Development";

        var services = new ServiceCollection();

       services.AddOptions<BlogApiJsonDirectAccessSetting>()
       .Configure(options => {
            options.DataPath = @"..\..\..\Data\";
            options.BlogPostsFolder = "Blogposts";
            options.TagsFolder = "Tags";
            options.CategoriesFolder = "Categories";
            options.CommentsFolder = "Comments";
       });
        services.AddScoped<IBlogApi, BlogApiJsonDirectAccess>();



        var provider = services.BuildServiceProvider();
        Api = provider.GetService<IBlogApi>();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
