using Processor.API.Entities;

namespace Register.API.DTOs;
public class CustomerRequestDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string Country { get; set; }
    public string Uf { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string AddressNumber { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
}
