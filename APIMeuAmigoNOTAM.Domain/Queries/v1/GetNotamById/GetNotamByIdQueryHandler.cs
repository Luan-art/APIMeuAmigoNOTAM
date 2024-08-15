using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById
{
    public class GetNotamByIdQueryHandler : IRequestHandler<GetNotamByIdQuery, GetNotamByIdQueryResponse>
    {
        private readonly INotamRepository _repository;
        private readonly IMapper _mapper;

        public GetNotamByIdQueryHandler(INotamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<GetNotamByIdQueryResponse> Handle(GetNotamByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
