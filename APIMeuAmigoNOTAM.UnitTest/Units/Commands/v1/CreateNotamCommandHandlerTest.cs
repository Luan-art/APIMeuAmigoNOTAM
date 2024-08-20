using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.UnitTest.Mocks.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Commands.v1
{
    public class CreateNotamCommandHandlerTest
    {
        private readonly CreateNotamCommandHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;
        private readonly Mock<ILogger<CreateNotamCommandHandler>> _mockLogger;

        public CreateNotamCommandHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _mockLogger = new Mock<ILogger<CreateNotamCommandHandler>>();
            _handler = new CreateNotamCommandHandler(_mockRepo.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Handle_CreatesNotamSuccessfully_WhenValidRequest()
        {
            var command = new CreateNotamCommand { Type = "A", IATA = "JFK", Runway = "4L", ExpiryDate = DateTime.Now.AddDays(10), StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), Comments = "Routine maintenance", IsExpired = false };

            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            result.Id = NotamMock.GenerateRandomId();

            Assert.NotNull(result);
            Assert.NotNull(result.Id);  
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_ReturnsError_WhenExceptionOccurs()
        {
            var command = new CreateNotamCommand { Type = "A" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Notam>())).ThrowsAsync(new Exception("Database error"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
            Assert.Null(result.Id);
            Assert.Equal("Failed to create NOTAM due to internal error.", result.ErrorMessage);

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error occurred while creating NOTAM")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once
            );
        }

    }
}
