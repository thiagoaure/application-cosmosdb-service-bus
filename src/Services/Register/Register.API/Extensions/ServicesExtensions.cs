using Register.API.Interfaces.Services;
using Register.API.ServiceBus;
using Register.API.Services;

namespace Register.API.Extensions;

public static class ServicesExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IServiceBus, ServiceBusPublisher>();
    }
}
