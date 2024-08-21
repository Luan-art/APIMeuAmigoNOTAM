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
            var notam = new Notam { Id = "1", Type = "A" }; 
            var command = new UpdateNotamCommand { Id = "1", Type = "B" }; 
            _mockRepo.Setup(repo => repo.GetById("1")).ReturnsAsync(notam);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Notam>())).Returns(Task.CompletedTask);

            var response = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            _mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Notam>()), Times.Once);
            Assert.Equal("B", notam.Type); 
        }

        [Fact]
        public async Task Handle_ThrowsKeyNotFoundException_WhenNotamDoesNotExist()
        {
            _mockRepo.Setup(repo => repo.GetById("1")).ReturnsAsync((Notam)null);
            var command = new UpdateNotamCommand { Id = "1" };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ThrowsInvalidOperationException_WhenUpdateFails()
        {
            var notam = new Notam { Id = "2" };
            var command = new UpdateNotamCommand { Id = "2" };
            _mockRepo.Setup(repo => repo.GetById("2")).ReturnsAsync(notam);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Notam>())).ThrowsAsync(new Exception("Database failure"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
