using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using Microsoft.Extensions.Logging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandHandler : IRequestHandler<CreateNotamCommand, CreateNotamCommandResponse>
    {
        private readonly INotamRepository _repository;
        private readonly ILogger<CreateNotamCommandHandler> _logger;

        public CreateNotamCommandHandler(INotamRepository repository, ILogger<CreateNotamCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CreateNotamCommandResponse> Handle(CreateNotamCommand request, CancellationToken cancellationToken)
        {
            Notam notam = (Notam)request; 
            try
            {
                await _repository.AddAsync(notam);
                _logger.LogInformation("Notam created successfully with ID: {Id}", notam.Id);
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
