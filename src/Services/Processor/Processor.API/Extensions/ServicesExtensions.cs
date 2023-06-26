using Processor.API.Interfaces.Services;
using Processor.API.Services;

namespace Processor.API.Extensions;

public static class ServicesExtensions
{
    public static void AddCustomProcessorServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerProcessorService, CustomerProcessorService>();
    }
}
