using BloodTesting.Application.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BloodTesting.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ScheduleTestUseCase>();

        return services;
    }
}
