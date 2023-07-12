using MediatR;

namespace CustomersExercise.Application.Commands.Customer.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public int Id { get; set; }
    }
}
