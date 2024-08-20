using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Commands.v1
{
    public class UpdateNotamCommandHandlerTest
    {
        private readonly UpdateNotamCommandHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;

        public UpdateNotamCommandHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _handler = new UpdateNotamCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_UpdatesNotam_WhenNotamExists()
        {
            // Arrange
            var notam = new Notam { Id = "1", Type = "A" }; // Existing Notam data
            var command = new UpdateNotamCommand { Id = "1", Type = "B" }; // Update details
            _mockRepo.Setup(repo => repo.GetById("1")).ReturnsAsync(notam);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Notam>())).Returns(Task.CompletedTask);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            _mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Notam>()), Times.Once);
            Assert.Equal("B", notam.Type); // Check if the Type has been updated
        }

        [Fact]
        public async Task Handle_ThrowsKeyNotFoundException_WhenNotamDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetById("99")).ReturnsAsync((Notam)null);
            var command = new UpdateNotamCommand { Id = "99" };

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ThrowsInvalidOperationException_WhenUpdateFails()
        {
            // Arrange
            var notam = new Notam { Id = "2" };
            var command = new UpdateNotamCommand { Id = "2" };
            _mockRepo.Setup(repo => repo.GetById("2")).ReturnsAsync(notam);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Notam>())).ThrowsAsync(new Exception("Database failure"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
