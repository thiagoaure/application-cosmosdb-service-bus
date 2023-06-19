using Register.API.Entities;
using Register.API.DTOs;

namespace Register.API.Interfaces.Services;
public interface ICustomerService
{
    Task<CustomerResponseDTO> SaveCustomer(CustomerRequestDTO customer);
    Task<IEnumerable<CustomerResponseDTO?>> GetAll();
}
