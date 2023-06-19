using Register.API.DTOs;

namespace Register.API.Interfaces.Services;

public interface IServiceBus
{
    Task SendMessageToQueue(CustomerRequestDTO customer);
}
