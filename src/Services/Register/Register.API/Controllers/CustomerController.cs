using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Register.API.DTOs;
using Register.API.Filters;
using Register.API.Helpers;
using Register.API.Interfaces.Services;

namespace Processor.API.Controllers;
[Route("api/customer")]
[ApiController]
public class CustomerController
{
    private readonly ICustomerService _customerService;
    private readonly IServiceBus _serviceBus;

    public CustomerController(ICustomerService customerService, IServiceBus serviceBus)
    {
        _customerService = customerService;
        _serviceBus = serviceBus;
    }

    [HttpPost]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    [ServiceFilter(typeof(ExceptionFilter))]
    [ServiceFilter(typeof(ActionFilter))]
    public async Task<IActionResult> CreateCustomerAsync(
        [FromBody] CustomerRequestDTO request
    )
    {
        try
        {
            var response = await _customerService.SaveCustomer(request);
            await _serviceBus.SendMessageToQueue(request);

            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            var json = JsonConvert.SerializeObject(ex)!;
            return new BadRequestObjectResult(json);
        }
    }
}
