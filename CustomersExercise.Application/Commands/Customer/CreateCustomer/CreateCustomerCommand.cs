using CustomersExercise.Application.Dto.Customer;
using MediatR;

namespace CustomersExercise.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public CreateCustomerDto CreateCustomerDto { get; set; }
    }
}
