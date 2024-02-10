using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using WebApplication4;
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



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
