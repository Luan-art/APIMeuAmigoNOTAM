using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using APIMeuAmigoNOTAM.UnitTest.Mocks.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Queries.v1
{
    public class GetNotamByIdQueryHandlerTest
    {
        private readonly GetNotamByIdQueryHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;

        public GetNotamByIdQueryHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _handler = new GetNotamByIdQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task GetNotamByIdQueryHandler_ReturnsNotam_WhenNotamExists()
        {
            var notam = NotamMock.GetNotams()[0]; 
            _mockRepo.Setup(repo => repo.GetById("1")).ReturnsAsync(notam);

            var query = new GetNotamByIdQuery { Id = "1" };

            var result = await _handler.Handle(query, new System.Threading.CancellationToken());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetNotamByIdQueryHandler_ReturnsNull_WhenNotamDoesNotExist()
        {
            _mockRepo.Setup(repo => repo.GetById("99")).ReturnsAsync((Notam)null);

            var query = new GetNotamByIdQuery { Id = "99" };

            var result = await _handler.Handle(query, new System.Threading.CancellationToken());

            Assert.Null(result);
        }
    }
}
