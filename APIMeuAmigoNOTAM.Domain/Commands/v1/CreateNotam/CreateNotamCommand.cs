using APIMeuAmigoNOTAM.Domain.Entities.v1;
using MediatR;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommand : IRequest<CreateNotamCommandResponse>
    {
        public string Type { get; set; }
        public string IATA { get; set; }
        public string Runway { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Comments { get; set; }
        public bool IsExpired { get; set; }

        public static explicit operator Notam(CreateNotamCommand command)
        {
            return new Notam
            {
                Type = command.Type,
                IATA = command.IATA,
                Runway = command.Runway,
                ExpiryDate = command.ExpiryDate,
                StartTime = command.StartTime,
                EndTime = command.EndTime,
                Comments = command.Comments,
                IsExpired = command.IsExpired
            };
        }
    }
}
