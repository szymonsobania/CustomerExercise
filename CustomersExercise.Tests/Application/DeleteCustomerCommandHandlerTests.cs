using CustomersExercise.Application.Commands.Customer.DeleteCustomer;
using CustomersExercise.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomersExercise.Tests.Application
{
    public class DeleteCustomerCommandHandlerTests : BaseTest
    {
        private DeleteCustomerCommandHandler sut;
        private Mock<ICustomerRepository> repoMock;
        private Mock<ILogger<DeleteCustomerCommandHandler>> loggerMock;

        public DeleteCustomerCommandHandlerTests()
        {
            repoMock = new Mock<ICustomerRepository>();
            loggerMock = new Mock<ILogger<DeleteCustomerCommandHandler>>();
            sut = new DeleteCustomerCommandHandler(repoMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task RemoveCustomer_Success()
        {
            // Arrange  
            repoMock.Setup(x => x.RemoveCustomerAsync(It.IsInRange<int>(1, 5, Range.Inclusive), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var query = new DeleteCustomerCommand()
            {
                Id = 1
            };

            // Act
            var response = await sut.Handle(query, _cancellationToken);

            // Assert
            response.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task RemoveCustomer_NotFound()
        {
            // Arrange  
            repoMock.Setup(x => x.RemoveCustomerAsync(It.IsInRange<int>(1,5, Range.Inclusive), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var query = new DeleteCustomerCommand()
            {
                Id = 6
            };

            // Act
            var response = await sut.Handle(query, _cancellationToken);

            // Assert
            response.IsSuccess.ShouldBeFalse();
        }
    }
}
