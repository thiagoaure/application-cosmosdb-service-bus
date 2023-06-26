using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Processor.API.DTOs;
using Processor.API.Interfaces.Services;

namespace Processor.API.Controllers;

[ApiController]
[Route("api/customer-processor")]
public class CustomerProcessorController
{
    private readonly ICustomerProcessorService _customerProcessorService;

    public CustomerProcessorController(ICustomerProcessorService customerProcessorService)
    {
        _customerProcessorService = customerProcessorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        try
        {
            var response = await _customerProcessorService.GetCustomerId(id);

            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            var response = await _customerProcessorService.DeleteCustomer(id);

            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateDTO customer)
    {
        try
        {
            var response = await _customerProcessorService.UpdateCustomer(customer);

            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }



}
