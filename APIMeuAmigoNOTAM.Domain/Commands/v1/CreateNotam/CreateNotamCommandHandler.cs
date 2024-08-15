using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandHandler : IRequestHandler<CreateNotamCommand, CreateNotamCommandResponse>
    {
        private readonly INotamRepository _repository;
        private readonly IMapper _mapper;

        public CreateNotamCommandHandler(INotamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateNotamCommandResponse> Handle(CreateNotamCommand request, CancellationToken cancellationToken)
        {
            var notam = _mapper.Map<CreateNotamCommand, Notam>(request);
            try
            {
                await _repository.AddAsync(notam);
            }
            catch (Exception ex)
            {

                return null;
            }

            return _mapper.Map<CreateNotamCommandResponse>(notam);
        }
    }
}