using AutoMapper;
using Moq;
using Register.API.DTOs;
using Register.API.Entities;
using Register.API.Interfaces.Repositories;
using Register.API.Services;
using Xunit;

namespace Register.API.Test;

[TestClass]
public class CustomerServiceTests
{
    private Mock<ICustomerRespository> _customerRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private CustomerService _customerService;

    [TestInitialize]
    public void Setup()
    {
        _customerRepositoryMock = new Mock<ICustomerRespository>();
        _mapperMock = new Mock<IMapper>();
        _customerService = new CustomerService(_customerRepositoryMock.Object, _mapperMock.Object);
    }

    [TestMethod]
    public async Task GetAll_ShouldReturnAllCustomers()
    {
        // Arrange
        var customers = new List<Customer>
        {
            FakeCustomer(),
            FakeCustomer()
        };

        var customerResponseDTOs = new List<CustomerResponseDTO>
        {
            FakeCustomerResDTO(),
            FakeCustomerResDTO()
        };

        _customerRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(customers);
        _mapperMock.Setup(m => m.Map<IEnumerable<CustomerResponseDTO>>(customers)).Returns(customerResponseDTOs);

        // Act
        var result = await _customerService.GetAll();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customerResponseDTOs.Count, result.Count());
    }

    [TestMethod]
    public async Task SaveCustomer_ShouldSaveCustomerAndReturnResponse()
    {
        // Arrange
        var customerRequestDTO = FakeCustomerReqDTO();
        var customer = FakeCustomer();
        var customerResponse = FakeCustomer();
        var customerResponseDTO = FakeCustomerResDTO();

        _mapperMock.Setup(m => m.Map<Customer>(customerRequestDTO)).Returns(customer);
        _customerRepositoryMock.Setup(r => r.SaveCustomer(customer)).ReturnsAsync(customerResponse);
        _mapperMock.Setup(m => m.Map<CustomerResponseDTO>(customerResponse)).Returns(customerResponseDTO);

        // Act
        var result = await _customerService.SaveCustomer(customerRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customerResponseDTO, result);
    }

    private static Customer FakeCustomer ()
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = "teste",
            Email = "teste@example.com",
            Address = new Address
            {
                Country = "Country",
                Uf = "UF",
                City = "City",
                ZipCode = "12345",
                AddressNumber = "123",
                Street = "Street",
                District = "District"
            },
            Document = "1234567890"
        };

    }
    private static CustomerResponseDTO FakeCustomerResDTO()
    {
        return new CustomerResponseDTO
        {
            Id = Guid.NewGuid(),
            Name = "teste",
            Email = "teste@example.com",
            Address = new Address
            {
                Country = "Country",
                Uf = "UF",
                City = "City",
                ZipCode = "12345",
                AddressNumber = "123",
                Street = "Street",
                District = "District"
            },
            Document = "1234567890"
        };

    }
    private static CustomerRequestDTO FakeCustomerReqDTO()
    {
        return new CustomerRequestDTO
        {
            Name = "teste",
            Email = "teste@example.com",
            Country = "Country",
            Uf = "UF",
            City = "City",
            ZipCode = "12345",
            AddressNumber = "123",
            Street = "Street",
            District = "District",
            Document = "1234567890"
        };

    }
}
