using Register.API.Entities;

namespace Register.API.DTOs;
public class CustomerResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string Document { get; set; }
}
