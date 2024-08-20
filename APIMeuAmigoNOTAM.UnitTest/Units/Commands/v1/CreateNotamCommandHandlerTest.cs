using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
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
            
            var notam = new Notam { Id = "1", Type = "A" };
            var command = new CreateNotamCommand { Type = "A" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Notam>())).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.Success);
            Assert.Equal("1", result.Id);
            _mockLogger.Verify(logger => logger.LogInformation("Notam created successfully with ID: {Id}", It.IsAny<object[]>()), Times.Once);
            _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Notam>()), Times.Once);
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
            _mockLogger.Verify(logger => logger.LogError(It.IsAny<Exception>(), "Error occurred while creating NOTAM"), Times.Once);
        }
    }
}
