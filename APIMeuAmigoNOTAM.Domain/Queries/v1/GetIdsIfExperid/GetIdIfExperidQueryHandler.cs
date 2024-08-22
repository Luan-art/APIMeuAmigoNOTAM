using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetIdsIfExperid
{
    public class GetIdIfExperidQueryHandler : IRequestHandler<GetIdIfExperidQuery, GetIdIfExperidQueryResponse>
    {
        private readonly INotamRepository _repository;

        public GetIdIfExperidQueryHandler(INotamRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetIdIfExperidQueryResponse> Handle(GetIdIfExperidQuery request, CancellationToken cancellationToken)
        {
            var notams = await _repository.GetAllAsync();

            return (GetIdIfExperidQueryResponse)notams;
        }
    }
}
