using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam
{
    public class UpdateNotamCommandHandler : IRequestHandler<UpdateNotamCommand, UpdateNotamCommandResponse>
    {
        private readonly INotamRepository _repository;
        private readonly IMapper _mapper;

        public UpdateNotamCommandHandler(INotamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateNotamCommandResponse> Handle(UpdateNotamCommand request, CancellationToken cancellationToken)
        {
            var existingNotam = await _repository.GetById(request.Id);
                
            if (existingNotam == null)
            {
                throw new KeyNotFoundException($"Notam with ID {request.Id} not found.");
            }

            _mapper.Map(request, existingNotam);

            existingNotam.Id = request.Id;

            try
            {
                await _repository.UpdateAsync(existingNotam);
            }
            catch (Exception ex)
            {
                 throw new InvalidOperationException("Failed to update Notam.", ex);
            }

            var response = _mapper.Map<UpdateNotamCommandResponse>(existingNotam);
            return response;
        }
        
    }
}
