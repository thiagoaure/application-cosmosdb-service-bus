using Processor.API.Interfaces.Repositories;
using Processor.API.Repositories;

namespace Processor.API.Extensions;

public static class RepositoriesExtensions
{
    public static void AddCustomProcessorRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerProcessorRepository, CustomerProcessorRepository>();
    }
}
