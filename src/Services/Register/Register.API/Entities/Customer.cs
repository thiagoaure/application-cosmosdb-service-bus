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
}
