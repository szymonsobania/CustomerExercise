using CustomersExercise.Application.Commands.Customer.CreateCustomer;
using CustomersExercise.Application.Dto.Customer;
using CustomersExercise.Domain.Entities;
using CustomersExercise.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomersExercise.Tests.Application
{
    public class CreateCustomerCommandHandlerTests : BaseTest
    {
        private CreateCustomerCommandHandler sut;
        private Mock<ICustomerRepository> repoMock;
        private Mock<ILogger<CreateCustomerCommandHandler>> loggerMock;

        public CreateCustomerCommandHandlerTests()
        {
            repoMock = new Mock<ICustomerRepository>();
            loggerMock = new Mock<ILogger<CreateCustomerCommandHandler>>();
            sut = new CreateCustomerCommandHandler(_mapper, repoMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task CreateCustomer_Success()
        {
            // Arrange  
            repoMock.Setup(x => x.AddCustomerAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var query = new CreateCustomerCommand()
            {
                CreateCustomerDto = new CreateCustomerDto()
                {
                    Firstname = "John",
                    Surname = "Smith"
                }
            };

            // Act
            var response = await sut.Handle(query, _cancellationToken);

            // Assert
            response.Id.ShouldBe(1);           
        }


        [Fact]
        public async Task CreateCustomer_EmptyCustomer()
        {
            // Arrange  
            repoMock.Setup(x => x.AddCustomerAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var query = new CreateCustomerCommand() { };

            // Act
            var response = await sut.Handle(query, _cancellationToken);

            // Assert
            response.IsSuccess.ShouldBeFalse();
        }
    }
}
