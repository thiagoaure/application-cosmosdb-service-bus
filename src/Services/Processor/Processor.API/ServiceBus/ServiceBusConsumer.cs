using Azure.Messaging.ServiceBus;
using Processor.API.Helpers;
using Processor.API.Interfaces.ServiceBus;

namespace Processor.API.ServiceBus;

public class ServiceBusConsumer : IServiceBus
{
    private readonly string _serviceBusConnectionString = ConfigurationConnectionStrings.ConfigConnection()
        .GetValue<string>("BusConnectionString")!;

    public async Task ProcessMessage()
    {
        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };
        ServiceBusClient client = new (_serviceBusConnectionString, clientOptions);
        ServiceBusProcessor processor = client.CreateProcessor("customer", new ServiceBusProcessorOptions());

        try
        {
            processor.ProcessMessageAsync += MessageHandler;

            processor.ProcessErrorAsync += ErrorHandler;

            await processor.StartProcessingAsync();

            Console.WriteLine("Wait for a minute and then press any key to end the processing");
            Console.ReadKey();

            Console.WriteLine("\nStopping the receiver...");
            await processor.StopProcessingAsync();
            Console.WriteLine("Stopped receiving messages");

        } catch (Exception ex)
        {
            // handle exception here
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }
    }
    public async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        Console.WriteLine($"Received: {body}");

        await args.CompleteMessageAsync(args.Message);
    }
    public Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }

}
