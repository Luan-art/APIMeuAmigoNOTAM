using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam
{
    public class UpdateNotamCommandHandler : IRequestHandler<UpdateNotamCommand, UpdateNotamCommandResponse>
    {
        private readonly INotamRepository _repository;

        public UpdateNotamCommandHandler(INotamRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateNotamCommandResponse> Handle(UpdateNotamCommand request, CancellationToken cancellationToken)
        {
            var existingNotam = await _repository.GetById(request.Id);

            if (existingNotam == null)
            {
                throw new KeyNotFoundException($"Notam with ID {request.Id} not found.");
            }

            
            existingNotam.Type = request.Type;
            existingNotam.IATA = request.IATA;
            existingNotam.Runway = request.Runway;
            existingNotam.ExpiryDate = request.ExpiryDate;
            existingNotam.StartTime = request.StartTime;
            existingNotam.EndTime = request.EndTime;
            existingNotam.Comments = request.Comments;
            existingNotam.IsExpired = request.IsExpired;

            try
            {
                await _repository.UpdateAsync(existingNotam);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to update Notam.", ex);
            }

            return (UpdateNotamCommandResponse)existingNotam;
        }
    }
}
