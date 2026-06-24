using BloodTesting.Adapters.EfSqlite.Persistence;
using BloodTesting.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodTesting.Adapters.EfSqlite;

public static class DependencyInjection
{
    public static IServiceCollection AddEfSqliteAdapter(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BloodTesting")
            ?? "Data Source=BloodTesting.db";

        services.AddDbContext<BloodTestingDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IPatientRepository, EfPatientRepository>();
        services.AddScoped<ITestRepository, EfTestRepository>();

        return services;
    }
}
