using AutoMapper;
using Processor.API.DTOs;
using Processor.API.Entities;
using Processor.API.Interfaces.Repositories;
using Processor.API.Interfaces.Services;

namespace Processor.API.Services;
public class CustomerProcessorService : ICustomerProcessorService
{
    private readonly ICustomerProcessorRepository _customerProcessorRepository;
    private readonly IMapper _mapper;

    public CustomerProcessorService(ICustomerProcessorRepository customerProcessorRepository, IMapper mapper)
    {
        _customerProcessorRepository = customerProcessorRepository;
        _mapper = mapper;
    }

    public async Task<CustomerResponseDTO> DeleteCustomer(Guid id)
    {
        var response = await _customerProcessorRepository.DeleteCustomer(id);
        var customer = _mapper.Map<CustomerResponseDTO>(response);
        return customer;
    }

    public async Task<CustomerResponseDTO> GetCustomerId(Guid id)
    {
        var response = await _customerProcessorRepository.GetCustomerId(id);
        var customer = _mapper.Map<CustomerResponseDTO>(response);
        return customer;
    }

    public async Task<CustomerResponseDTO> UpdateCustomer(CustomerUpdateDTO customer)
    {
        Customer newCustomer = new Customer();
        var oldCustomer = await _customerProcessorRepository.GetCustomerId(customer.Id);
        if (oldCustomer != null)
        {
            newCustomer = _mapper.Map<Customer>(customer);
            var response = await _customerProcessorRepository.UpdateCustomer(newCustomer, oldCustomer);
            return _mapper.Map<CustomerResponseDTO>(response);
        } else
        {
            return default;
        }
    }
}
