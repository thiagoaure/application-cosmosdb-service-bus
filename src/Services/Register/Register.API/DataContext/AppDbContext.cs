using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Register.API.Entities;
using Register.API.Helpers;

namespace Register.API.DataContext;
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

    private async Task InitializeDatabaseAsync()
    {

        endpointAccount = ConfigurationConnectionStrings.ConfigConncetion().
            GetValue<string>("AccountEndpoint")!;
        keyAccount = ConfigurationConnectionStrings.ConfigConncetion().
            GetValue<string>("AccountKey")!;

        CosmosClient cosmosClient = new CosmosClient(endpointAccount, keyAccount);

        DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
        Database database = databaseResponse.Database;
       
        ContainerProperties containerProperties = new ContainerProperties(containerName, "/particao");

        ContainerResponse containerResponse = await database.CreateContainerIfNotExistsAsync(containerProperties, throughput: 400);
        Container container = containerResponse.Container;

        Console.WriteLine("DB and Conatainer was created");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        InitializeDatabaseAsync().Wait();
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