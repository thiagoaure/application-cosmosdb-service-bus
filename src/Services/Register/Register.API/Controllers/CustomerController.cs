using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Processor.API.Entities;
using Register.API.DTOs;
using Register.API.Interfaces.Services;

namespace Processor.API.Controllers;
[Route("api/customer")]
[ApiController]
public class CustomerController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(
        [FromBody] CustomerRequestDTO request
    )
    {
        try
        {
            var response = await _customerService.SaveCustomer( request );
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }
}
