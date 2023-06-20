using Microsoft.AspNetCore.Mvc;
using Moq;
using Register.API.Controllers;
using Register.API.DTOs;
using Register.API.Entities;
using Register.API.Interfaces.Services;
using Xunit;

namespace Register.API.Test;

[TestClass]
public class CustomerControllerTest
{
    [TestMethod]
    public async Task CreateCustomerAsync_ShouldReturnOkResult()
    {
        // Arrange
        var request = FakeCustomerReqDTO();
        var res = FakeCustomerResDTO();
        var customerServiceMock = new Mock<ICustomerService>();
        customerServiceMock.Setup(serv => serv.SaveCustomer(request))
            .ReturnsAsync(res)
            .Verifiable();
        var serviceBusMock = new Mock<IServiceBus>();

        var controller = new CustomerController(customerServiceMock.Object, serviceBusMock.Object);

        // Act
        var result = await controller.CreateCustomerAsync(request);

        // Assert
        Assert.IsNotNull(result);
        var okResult = result as OkObjectResult;
        var response = okResult.Value as CustomerResponseDTO;
        Assert.IsNotNull(response);
    }

    [TestMethod]
    public async Task GetAllCustomersAsync_ShouldReturnOkResult()
    {
        // Arrange
        var customerServiceMock = new Mock<ICustomerService>();
        var serviceBusMock = new Mock<IServiceBus>();

        var controller = new CustomerController(customerServiceMock.Object, serviceBusMock.Object);

        // Act
        var result = await controller.GetAllCustomersAsync();

        // Assert
        Assert.IsNotNull(result);
        var okResult = result as OkObjectResult;
        var response = okResult.Value as CustomerResponseDTO[];
        Assert.IsNotNull(response);
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
}
