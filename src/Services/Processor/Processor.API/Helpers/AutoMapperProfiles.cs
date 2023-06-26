using AutoMapper;
using Processor.API.Entities;
using Processor.API.DTOs;

namespace Processor.API.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Customer, CustomerResponseDTO>();
        CreateMap<Customer, CustomerUpdateDTO>()
            .ReverseMap()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
            {
                Country = src.Country,
                Uf = src.Uf,
                City = src.City,
                ZipCode = src.ZipCode,
                AddressNumber = src.AddressNumber,
                Street = src.Street,
                District = src.District
            }));
    }
}
