using AutoMapper;
using Processor.API.Entities;
using Register.API.DTOs;
using Register.API.Interfaces.Repositories;
using Register.API.Interfaces.Services;

namespace Register.API.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRespository _customerRespository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRespository customerrespository, IMapper mapper)
    {
        _customerRespository = customerrespository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseDTO> SaveCustomer(CustomerRequestDTO request)
    {
        Customer customer = _mapper.Map<Customer>(request);
        return await _customerRespository.SaveCustomer(customer);
    }
}
