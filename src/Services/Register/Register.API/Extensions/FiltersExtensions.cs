using Register.API.Repositories;
using Register.API.Filters;
using Register.API.Interfaces.Repositories;
using System.Diagnostics;

namespace Register.API.Extensions;

public static class FiltersExtensions
{
    public static void AddCustomFilters(this IServiceCollection services)
    {
        services.AddScoped<AuthorizationFilter>();
        services.AddScoped<ExceptionFilter>();
        services.AddScoped<ActionFilter>();
        services.AddSingleton<Stopwatch>();

    }
}
