using APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID;
using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class DeleteNotamByIdCommandHandler : IRequestHandler<DeleteNotamByIdCommand, DeleteNotamByIdCommandResponse>
{
    private readonly INotamRepository _repository;
    private readonly IMapper _mapper;

    public DeleteNotamByIdCommandHandler(INotamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeleteNotamByIdCommandResponse> Handle(DeleteNotamByIdCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            return new DeleteNotamByIdCommandResponse
            {
                Success = false,
            };
        }

        try
        {
            var notam = await _repository.GetById(request.Id);
            if (notam == null)
            {
                return new DeleteNotamByIdCommandResponse
                {
                    Success = false,
                };
            }

            bool deleteResult = await _repository.DeleteAsync(notam.Id);
            if (!deleteResult)
            {
                return new DeleteNotamByIdCommandResponse
                {
                    Success = false,
                };
            }

            return new DeleteNotamByIdCommandResponse
            {
                Success = true,
            };
        }
        catch (Exception ex)
        {
            return new DeleteNotamByIdCommandResponse
            {
                Success = false,
            };
        }
    }
}
