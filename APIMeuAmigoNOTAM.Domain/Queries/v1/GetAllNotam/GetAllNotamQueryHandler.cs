using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQueryHandler : IRequestHandler<GetAllNotamQuery, GetAllNotamQueryResponse>
    {
        private readonly INotamRepository _repository;
 
        public GetAllNotamQueryHandler(INotamRepository repository)
        {
            _repository = repository;
         }

        public async Task<GetAllNotamQueryResponse> Handle(GetAllNotamQuery request, CancellationToken cancellationToken)
        {

            var notam = await _repository.GetAllAsync();

            return (GetAllNotamQueryResponse)notam;
        }
    }
}
