using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam;
using APIMeuAmigoNOTAM.UnitTest.Mocks.Entities;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Queries.v1
{
    public class GetAllNotamQueryHandlerTest
    {
        private readonly GetAllNotamQueryHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;

        public GetAllNotamQueryHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _handler = new GetAllNotamQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ReturnsAllNotam_WhenNotamsExist()
        {
            var notams = NotamMock.GetNotams();
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(notams);
            var request = new GetAllNotamQuery();

            var result = await _handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetAllNotamQueryResponse>(result);
            Assert.Equal(notams.Count, result.Notams.Count);
        }

        [Fact]
        public async Task Handle_ReturnsEmptyResponse_WhenNoNotamsExist()
        {
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Notam>());
            var request = new GetAllNotamQuery();

            var result = await _handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetAllNotamQueryResponse>(result);
            Assert.Empty(result.Notams);
        }
    }
}
