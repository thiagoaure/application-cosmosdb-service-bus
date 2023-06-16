using Processor.API.Entities;

namespace Register.API.Interfaces.Repositories;
public interface ICustomerRespository
{
    Task<Customer> SaveCustomer(Customer customer);
}

