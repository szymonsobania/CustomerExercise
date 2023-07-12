using CustomersExercise.Domain.Entities;

namespace CustomersExercise.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        public Task<IList<Customer>> GetCustomersAsync(CancellationToken cancellationToken);       
        public Task<int> AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
        public Task<bool> RemoveCustomerAsync(int id, CancellationToken cancellationToken);

    }
}
