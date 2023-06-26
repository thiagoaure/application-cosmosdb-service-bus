using Processor.API.Constants.Enums;
using System.ComponentModel.DataAnnotations;

namespace Processor.API.Entities;
public class Customer
{
    [Key]
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string Document { get; set; }
    public TypeSubscription Subscription { get; set; }
    public bool? HasGift { get; set; }
}
