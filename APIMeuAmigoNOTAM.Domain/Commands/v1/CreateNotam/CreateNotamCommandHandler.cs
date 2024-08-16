using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandHandler : IRequestHandler<CreateNotamCommand, CreateNotamCommandResponse>
    {
        private readonly INotamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNotamCommandHandler> _logger;

        public CreateNotamCommandHandler(INotamRepository repository, IMapper mapper, ILogger<CreateNotamCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateNotamCommandResponse> Handle(CreateNotamCommand request, CancellationToken cancellationToken)
        {
            var notam = _mapper.Map<Notam>(request);
            try
            {
                await _repository.AddAsync(notam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating NOTAM");
                return new CreateNotamCommandResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to create NOTAM due to internal error."
                };
            }

            return new CreateNotamCommandResponse
            {
                Id = notam.Id,
                Success = true,
                ErrorMessage = null
            };
        }
    }
}
