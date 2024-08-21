using APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Commands.v1
{
    public class DeleteNotamCommandHandlerTest
    {
        private readonly DeleteNotamByIdCommandHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;

        public DeleteNotamCommandHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _handler = new DeleteNotamByIdCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ReturnsFailure_WhenIdIsNullOrEmpty()
        {
            var command = new DeleteNotamByIdCommand { Id = "" };
            
            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task Handle_DeletesNotam_WhenNotamExists()
        {
            var command = new DeleteNotamByIdCommand { Id = "1" };
            _mockRepo.Setup(repo => repo.GetById("1")).ReturnsAsync(new Notam { Id = "1" });
            _mockRepo.Setup(repo => repo.DeleteAsync("1")).ReturnsAsync(true);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.Success);
            _mockRepo.Verify(repo => repo.DeleteAsync("1"), Times.Once);
        }

        [Fact]
        public async Task Handle_ReturnsFailure_WhenNotamDoesNotExist()
        {
            var command = new DeleteNotamByIdCommand { Id = "99" };
            _mockRepo.Setup(repo => repo.GetById("99")).ReturnsAsync((Notam)null);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task Handle_ReturnsFailure_WhenDeletionFails()
        {
            var command = new DeleteNotamByIdCommand { Id = "2" };
            _mockRepo.Setup(repo => repo.GetById("2")).ReturnsAsync(new Notam { Id = "2" });
            _mockRepo.Setup(repo => repo.DeleteAsync("2")).ReturnsAsync(false);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task Handle_CatchesExceptions_AndReturnsFailure()
        {
            var command = new DeleteNotamByIdCommand { Id = "3" };
            _mockRepo.Setup(repo => repo.GetById("3")).ReturnsAsync(new Notam { Id = "3" });
            _mockRepo.Setup(repo => repo.DeleteAsync("3")).ThrowsAsync(new Exception("Database error"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.Success);
        }
    }
}
