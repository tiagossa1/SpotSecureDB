using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotSecureDB.Migrations;

var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json");

var configuration = builder.Build();

using (var serviceProvider = CreateServices())
using (var scope = serviceProvider.CreateScope())
{
    // Put the database update into a scope to ensure
    // that all resources will be disposed.
    UpdateDatabase(scope.ServiceProvider);
}

ServiceProvider CreateServices()
{
    return new ServiceCollection()
        // Add common FluentMigrator services
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // Add SQLite support to FluentMigrator
            .AddPostgres()
            // Set the connection string
            .WithGlobalConnectionString(configuration.GetConnectionString("SpotSecureDb"))
            // Define the assembly containing the migrations
            .ScanIn(typeof(CreateCarsTable).Assembly).For.Migrations())
        // Enable logging to console in the FluentMigrator way
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // Build the service provider
        .BuildServiceProvider(false);
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    // Instantiate the runner
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    // Execute the migrations
    runner.MigrateUp();
}