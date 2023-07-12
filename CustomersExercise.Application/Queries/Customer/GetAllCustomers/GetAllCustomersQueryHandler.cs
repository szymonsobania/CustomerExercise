using AutoMapper;
using CustomersExercise.Application.Dto.Customer;
using CustomersExercise.Domain.IRepositories;
using MediatR;

namespace CustomersExercise.Application.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<GetCustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<GetCustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);          
            return _mapper.Map<List<GetCustomerDto>>(customers);
        }
    }
}
