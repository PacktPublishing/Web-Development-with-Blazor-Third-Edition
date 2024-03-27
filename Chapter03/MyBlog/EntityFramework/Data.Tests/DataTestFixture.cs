
using Data.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions.Database;
using Raven.Client.Exceptions;
using Raven.Client.ServerWide.Operations;
using Raven.Client.ServerWide;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Tests;

[ExcludeFromCodeCoverage]
public class DataTestFixture : IAsyncLifetime
{
    public IBlogApi Api { get; set; } = default!;

    public async Task InitializeAsync()
    {
        var services = new ServiceCollection();

        var connectionString = "Server=(localdb)\\mssqllocaldb;Database=WebDevelopmentWithBlazor;Trusted_Connection=True;MultipleActiveResultSets=true";
        services.AddDbContextFactory<BlogDbContext>(options =>
            options.UseSqlServer(connectionString));
       

        services.AddScoped<IBlogApi,BlogApiEntityFrameworkDirectAccess>();
        var provider = services.BuildServiceProvider();
        Api = provider.GetService<IBlogApi>()!;

       //Apply Migrations
       IDbContextFactory<BlogDbContext> factory = provider.GetService<IDbContextFactory<BlogDbContext>>()!;
       factory.CreateDbContext().Database.Migrate();


        await Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public void EnsureDatabaseExists(IDocumentStore store, string database = null, bool createDatabaseIfNotExists = true)
    {
        database = database ?? store.Database;

        if (string.IsNullOrWhiteSpace(database))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(database));

        try
        {
            store.Maintenance.ForDatabase(database).Send(new GetStatisticsOperation());
        }
        catch (DatabaseDoesNotExistException)
        {
            if (createDatabaseIfNotExists == false)
                throw;

            try
            {
                store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(database)));
            }
            catch (ConcurrencyException)
            {
                // The database was already created before calling CreateDatabaseOperation
            }

        }
    }
}
