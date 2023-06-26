using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Processor.API.Entities;
using Processor.API.Helpers;

namespace Processor.API.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    private string endpointAccount = "";
    private string keyAccount = "";
    private string databaseName = "db_customer";
    private string containerName = "customer";

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        endpointAccount = ConfigurationConnectionStrings.ConfigConnection().
            GetValue<string>("AccountEndpoint")!;
        keyAccount = ConfigurationConnectionStrings.ConfigConnection().
            GetValue<string>("AccountKey")!;

        optionsBuilder.UseCosmos(
            endpointAccount,
            keyAccount,
            databaseName,
            options =>
            {
                options.ConnectionMode(ConnectionMode.Gateway);
                options.Region("West US");
            }
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(x =>
        {
            x.ToContainer("customer");
            x.OwnsOne(u => u.Address);
        });

    }
}

