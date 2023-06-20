using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.ServiceBus;
using Register.API.DTOs;
using Register.API.Interfaces.Services;
using System.Text;
using Register.API.Helpers;

namespace Register.API.ServiceBus;

public class ServiceBusPublisher : IServiceBus
{
    private readonly string _serviceBusConnectionString = ConfigurationConnectionStrings.ConfigConnection()
            .GetValue<string>("BusConnectionString")!;
    public async Task SendMessageToQueue(CustomerRequestDTO customer){
        var queueName = "customer";

        var namespaceManager = new ManagementClient(_serviceBusConnectionString);
        var queeExist = await namespaceManager.QueueExistsAsync(queueName);

        if (!queeExist)
        {
            await namespaceManager.CreateQueueAsync(new QueueDescription(queueName));
        }

        var client = new QueueClient(_serviceBusConnectionString, queueName);

        string messageBody = System.Text.Json.JsonSerializer.Serialize(customer);
        var message = new Message(Encoding.UTF8.GetBytes(messageBody));

        await client.SendAsync(message);
        await client.CloseAsync();
    }
}
