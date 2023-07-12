using CustomersExercise.Application.Dto.Customer;
using MediatR;

namespace CustomersExercise.Application.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<GetCustomerDto>>
    {
    }
}
