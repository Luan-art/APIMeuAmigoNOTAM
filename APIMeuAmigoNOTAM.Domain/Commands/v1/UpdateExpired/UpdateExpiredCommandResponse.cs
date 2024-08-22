using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Entities.v1;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateExpired
{
    public class UpdateExpiredCommandResponse
    {
        public string Id { get; set; }
        public bool Success { get; set; }

    }
}