using Azure.Messaging.ServiceBus;

namespace Processor.API.Interfaces.ServiceBus;

public interface IServiceBus
{
    Task MessageHandler(ProcessMessageEventArgs args);
    Task ErrorHandler(ProcessErrorEventArgs args);
    Task ProcessMessage();
}
