using System.ComponentModel.DataAnnotations.Schema;

namespace Register.API.Entities;

[ComplexType]
public class Address
{
    public string Country { get; set; }
    public string Uf { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string AddressNumber { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
}
