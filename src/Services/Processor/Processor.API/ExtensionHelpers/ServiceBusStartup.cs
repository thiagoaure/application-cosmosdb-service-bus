using Processor.API.Interfaces;
using Processor.API.ServiceBus;

namespace Processor.API.ExtensionHelpers;

public static class ServiceBusStartup
{
    public static async Task AddCustomServiceBusAsync(this IServiceCollection services)
    {
        services.AddTransient<IServiceBus, ServiceBusConsumer>();
        var service = new ServiceBusConsumer();
        await service.ProcessMessage();
    }
}
