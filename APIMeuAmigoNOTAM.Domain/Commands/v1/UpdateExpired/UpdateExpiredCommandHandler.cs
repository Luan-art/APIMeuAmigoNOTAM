using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateExpired
{
    public class UpdateExpiredCommandHandler : IRequestHandler<UpdateExpiredCommand, UpdateExpiredCommandResponse>
    {
        private readonly INotamRepository _repository;

        public UpdateExpiredCommandHandler(INotamRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateExpiredCommandResponse> Handle(UpdateExpiredCommand request, CancellationToken cancellationToken)
        {
            var notam = await _repository.GetById(request.Id);
            if (notam == null)
            {
                return new UpdateExpiredCommandResponse
                {
                    Id = request.Id,
                    Success = false
                };
            }

            notam.IsExpired = !notam.IsExpired;
            await _repository.UpdateAsync(notam);

            return new UpdateExpiredCommandResponse
            {
                Id = notam.Id,
                Success = true
            };
        }
    }
}
