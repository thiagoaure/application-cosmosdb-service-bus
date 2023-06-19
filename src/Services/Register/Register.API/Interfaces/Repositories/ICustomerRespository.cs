using Register.API.Entities;
using Register.API.DTOs;

namespace Register.API.Interfaces.Repositories;
public interface ICustomerRespository
{
    Task<CustomerResponseDTO> SaveCustomer(Customer customer);
}

