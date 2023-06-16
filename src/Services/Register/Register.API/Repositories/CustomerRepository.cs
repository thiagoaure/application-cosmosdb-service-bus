using Microsoft.EntityFrameworkCore;
using Processor.API.DataContext;
using Processor.API.Entities;
using Register.API.Interfaces.Repositories;

namespace Processor.API.Repositories;

public class CustomerRepository : ICustomerRespository
{
    protected readonly AppDbContext DbSet;

    public CustomerRepository(AppDbContext dbSet)
    {
        DbSet = dbSet;
    }
    public async Task<Customer> SaveCustomer(Customer customer)
    {
        DbSet.Customer.Add(customer);
        await DbSet.SaveChangesAsync();
        return customer;
    }
}
