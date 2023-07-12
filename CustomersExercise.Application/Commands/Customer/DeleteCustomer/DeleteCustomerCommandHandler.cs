using AutoMapper;
using CustomersExercise.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomersExercise.Application.Commands.Customer.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
            ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.RemoveCustomerAsync(request.Id, cancellationToken);
            if (result)
            {
                _logger.LogInformation("Removed Customer with id: " + request.Id);
            }
            return new DeleteCustomerResponse() { IsSuccess = result };
        }
    }
}
