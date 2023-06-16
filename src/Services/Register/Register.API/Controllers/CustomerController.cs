using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Processor.API.Entities;
using Register.API.Interfaces.Repositories;

namespace Processor.API.Controllers;
[Route("api/customer")]
[ApiController]
public class CustomerController
{
    private readonly ICustomerRespository _customerRepository;

    public CustomerController(ICustomerRespository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(
        [FromBody] Customer customer
    )
    {
        try
        {
            var response = await _customerRepository.SaveCustomer( customer );
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }
}
