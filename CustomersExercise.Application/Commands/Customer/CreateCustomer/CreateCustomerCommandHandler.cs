using AutoMapper;
using CustomersExercise.Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomersExercise.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        public CreateCustomerCommandHandler(IMapper mapper,
            ICustomerRepository customerRepository,
            ILogger<CreateCustomerCommandHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(request.CreateCustomerDto);
            if (customer == null)
            {
                _logger.LogError("Can not add null object");
                return new CreateCustomerResponse() { IsSuccess = false };
            }           
            var id = await _customerRepository.AddCustomerAsync(customer, cancellationToken);
            _logger.LogInformation("Created Customer with id: " + id);
            return new CreateCustomerResponse() { Id = id };
        }
    }
}
