using System.ComponentModel.Design;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Migrations;

const string connectionString = "Server=.;Database=Library;Trusted_Connection=True;" +
                                "TrustServerCertificate=True;Integrated Security=true";

var serviceCollection = new ServiceCollection()
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb.AddSqlServer()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(_202402062251_CheckMigration).Assembly).For.Migrations())
    .BuildServiceProvider();
serviceCollection.GetRequiredService<IMigrationRunner>().MigrateUp();
