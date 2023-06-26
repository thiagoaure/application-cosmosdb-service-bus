using Processor.API.Constants.Enums;
using Processor.API.Entities;

namespace Processor.API.DTOs;

public class CustomerResponseDTO 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string Document { get; set; }
    public TypeSubscription Subscription;
    public bool? HasGift { get; set; }
}
