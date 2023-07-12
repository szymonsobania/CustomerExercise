using AutoMapper;
using CustomersExercise.Application.Dto.Customer;
using CustomersExercise.Domain.Entities;

namespace CustomersExercise.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
