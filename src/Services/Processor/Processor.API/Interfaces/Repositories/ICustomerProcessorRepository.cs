using Processor.API.DTOs;
using Processor.API.Entities;

namespace Processor.API.Interfaces.Repositories;

public interface ICustomerProcessorRepository
{
    Task<Customer?> GetCustomerId(Guid id);
    Task<Customer> UpdateCustomer(Customer newCustomer, Customer oldCustomer);
    Task<Customer> DeleteCustomer(Guid id);
}
