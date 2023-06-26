using Microsoft.EntityFrameworkCore;
using Processor.API.DataContext;
using Processor.API.Entities;
using Processor.API.Interfaces.Repositories;

namespace Processor.API.Repositories;

public class CustomerProcessorRepository : ICustomerProcessorRepository
{
    private readonly AppDbContext DbSet;

    public CustomerProcessorRepository(AppDbContext dbSet)
    {
        DbSet = dbSet;
    }

    public async Task<Customer> DeleteCustomer(Guid id)
    {
        var cust = await DbSet.Customer.FirstOrDefaultAsync(x => x.Id == id);
        DbSet.Customer.Remove(cust);
        await DbSet.SaveChangesAsync();
        return cust;
    }

    public async Task<Customer?> GetCustomerId(Guid id)
    {
        return await DbSet.Customer.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Customer> UpdateCustomer(Customer newCustomer, Customer oldCustomer)
    {
        DbSet.Entry(oldCustomer).CurrentValues.SetValues(newCustomer);
        await DbSet.SaveChangesAsync();
        return newCustomer;
    }
}
