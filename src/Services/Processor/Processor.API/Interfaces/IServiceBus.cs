using Azure.Messaging.ServiceBus;

namespace Processor.API.Interfaces;

public interface IServiceBus
{
    Task MessageHandler(ProcessMessageEventArgs args);
    Task ErrorHandler(ProcessErrorEventArgs args);
    Task ProcessMessage();
}
