
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

namespace Data.Tests;

[ExcludeFromCodeCoverage]
public class DataTestFixture : IAsyncLifetime
{
    public IBlogApi Api { get; set; } = default!;

    public async Task InitializeAsync()
    {
        var services = new ServiceCollection();

        //Set up your RavenDb Instance
        //This is using the public open instance, make sure not to store any sensitive data.
        //The databases will be deleted 
#warning Change the database name, This is using the public open instance, make sure not to store any sensitive data.
        var databaseName = $"WebDevelopmentWithBlazor";
        services.AddSingleton<IDocumentStore>(ctx =>
        {
            var store = new DocumentStore
            {
                Urls = new[] { "http://live-test.ravendb.net/" },
                Database = databaseName,
                //No need for cert for the test instance, make sure to protect your real instance and add the cert here.
                //Certificate = new X509Certificate2(Convert.FromBase64String(builder.Configuration["RavenCert"]), builder.Configuration["RavenPassword"])
            };
            store.Initialize();
            EnsureDatabaseExists(store);
            return store;
        });
        services.AddScoped<IBlogApi, BlogApiRavenDbDirectAccess>();

        var provider = services.BuildServiceProvider();
        Api = provider.GetService<IBlogApi>()!;
        await Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public void EnsureDatabaseExists(IDocumentStore store, string? database = null, bool createDatabaseIfNotExists = true)
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
