using Microsoft.EntityFrameworkCore;
using BloodTesting.Adapters.EfSqlite;
using BloodTesting.Adapters.EfSqlite.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEfSqliteAdapter(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloodTestingDbContext>();
    await db.Database.MigrateAsync();
}

app.Run();
