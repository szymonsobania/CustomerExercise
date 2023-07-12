using CustomersExercise.Application.Queries.Customer.GetAllCustomers;
using CustomersExercise.Domain.Entities;
using CustomersExercise.Domain.IRepositories;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CustomersExercise.Tests.Application
{
    public class GetAllCustomersQueryHandlerTests : BaseTest
    {
        private GetAllCustomersQueryHandler sut;
        private Mock<ICustomerRepository> repoMock;

        public GetAllCustomersQueryHandlerTests()
        {
            repoMock = new Mock<ICustomerRepository>();
            sut = new GetAllCustomersQueryHandler(_mapper, repoMock.Object);
        }

        [Fact]
        public async Task GetAllCustomers_Success()
        {
            // Arrange         
            var customer = new Customer() { Firstname = "John", Surname = "Smith", Id = 1};
            repoMock.Setup(x => x.GetCustomersAsync(_cancellationToken)).ReturnsAsync(new List<Customer>() { customer });
                       
            var query = new GetAllCustomersQuery();
          
            // Act
            var customers = await sut.Handle(query, _cancellationToken);

            // Assert
            customers.Count().ShouldBe(1);
            customers.FirstOrDefault(x => x.Id == 1).ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAllCustomers_NoCustomers()
        {
            // Arrange
            repoMock.Setup(x => x.GetCustomersAsync(_cancellationToken)).ReturnsAsync(new List<Customer>());

            var query = new GetAllCustomersQuery();

            // Act
            var customers = await sut.Handle(query, _cancellationToken);

            // Assert
            customers.ShouldNotBeNull();
            customers.Count().ShouldBe(0);          
        }
    }
}
