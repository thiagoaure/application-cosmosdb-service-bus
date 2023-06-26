using Processor.API.DTOs;

namespace Processor.API.Interfaces.Services;
public interface ICustomerProcessorService
{
    Task<CustomerResponseDTO> GetCustomerId(Guid id);
    Task<CustomerResponseDTO> UpdateCustomer(CustomerUpdateDTO customer);
    Task<CustomerResponseDTO> DeleteCustomer(Guid id);
}
