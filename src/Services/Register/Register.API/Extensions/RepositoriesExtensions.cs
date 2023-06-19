using Register.API.Repositories;
using Register.API.Interfaces.Repositories;

namespace Register.API.Extensions;
public static class RepositoriesExtensions
{
    public static void AddCustomRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRespository, CustomerRepository>();
    }
}
