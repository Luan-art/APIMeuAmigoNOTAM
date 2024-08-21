using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid;
using APIMeuAmigoNOTAM.UnitTest.Mocks.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APIMeuAmigoNOTAM.UnitTest.Units.Queries.v1
{
    public class GetNotamByIsExperidQueryHandlerTest
    {
        private readonly GetNotamByIsExperidQueryHandler _handler;
        private readonly Mock<INotamRepository> _mockRepo;

        public GetNotamByIsExperidQueryHandlerTest()
        {
            _mockRepo = new Mock<INotamRepository>();
            _handler = new GetNotamByIsExperidQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ReturnsAllNotamIsTrue_WhenNotamsExist()
        {
            var notams = NotamMock.GetNotams().Where(n => n.IsExpired).ToList(); 
            _mockRepo.Setup(repo => repo.GetIsExperidAsync(true)).ReturnsAsync(notams);
            var request = new GetNotamByIsExperidQuery { isExperid = true };

            var result = await _handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetNotamByIsExperidQueryResponse>(result);
            Assert.Equal(notams.Count, result.Notams.Count);  
        }

        [Fact]
        public async Task Handle_ReturnsAllNotamIsFalse_WhenNoNotamsExist()
        {
            var notams = NotamMock.GetNotams().Where(n => n.IsExpired).ToList();
            _mockRepo.Setup(repo => repo.GetIsExperidAsync(false)).ReturnsAsync(notams);
            var request = new GetNotamByIsExperidQuery { isExperid = false };

            var result = await _handler.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.IsType<GetNotamByIsExperidQueryResponse>(result);
            Assert.Equal(notams.Count, result.Notams.Count);
        }
    }
}
