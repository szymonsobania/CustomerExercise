using CustomersExercise.Domain.Entities;
using CustomersExercise.Domain.IRepositories;

namespace CustomersExercise.Infrastructure.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {       
        private readonly List<Customer> customerMock;

        public FakeCustomerRepository( )
        {            
            customerMock = new List<Customer>();
            customerMock.Add(new Customer() { Firstname = "John", Surname = "Smith", Id = 1 });
            customerMock.Add(new Customer() { Firstname = "Paul", Surname = "McDonald", Id = 2 });
        }

        public async Task<int> AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            int nextId = customerMock.Max(x => x.Id) + 1;
            customer.Id = nextId;
            customerMock.Add(customer);
            return nextId;
        }

        public async Task<IList<Customer>> GetCustomersAsync(CancellationToken cancellationToken)
        {
            return customerMock;
        }

        public async Task<bool> RemoveCustomerAsync(int id, CancellationToken cancellationToken)
        {
            var customerToDelete = customerMock.FirstOrDefault(x => x.Id == id);           
            customerMock.Remove(customerToDelete);
            return customerToDelete != null;
        }
    }
}
