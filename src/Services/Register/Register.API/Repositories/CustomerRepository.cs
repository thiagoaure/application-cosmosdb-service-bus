using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Register.API.DataContext;
using Register.API.Entities;
using Register.API.DTOs;
using Register.API.Interfaces.Repositories;

namespace Register.API.Repositories;

public class CustomerRepository : ICustomerRespository
{
    protected readonly AppDbContext DbSet;
    private readonly IMapper _mapper;

    public CustomerRepository(AppDbContext dbSet, IMapper mapper)
    {
        DbSet = dbSet;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Customer?>> GetAll()
    {
        return await DbSet.Customer.ToListAsync();
    }

    public async Task<Customer> SaveCustomer(Customer customer)
    {
        DbSet.Customer.Add(customer);
        await DbSet.SaveChangesAsync();
        return customer;
    }
}
