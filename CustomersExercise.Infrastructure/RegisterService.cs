using CustomersExercise.Domain.IRepositories;
using CustomersExercise.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomersExercise.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigureInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
        }
    }
}
