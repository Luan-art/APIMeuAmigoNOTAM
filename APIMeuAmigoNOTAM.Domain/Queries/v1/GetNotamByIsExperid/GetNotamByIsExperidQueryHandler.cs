using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid
{
    public class GetNotamByIsExperidQueryHandler : IRequestHandler<GetNotamByIsExperidQuery, GetNotamByIsExperidQueryResponse>
    {
        private readonly INotamRepository _repository;

        public GetNotamByIsExperidQueryHandler(INotamRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetNotamByIsExperidQueryResponse> Handle(GetNotamByIsExperidQuery request, CancellationToken cancellationToken)
        {
            var notam = await _repository.GetIsExperidAsync(request.isExperid);
            if (notam == null) return null;

            return (GetNotamByIsExperidQueryResponse)notam;
        }
 
    }
}
