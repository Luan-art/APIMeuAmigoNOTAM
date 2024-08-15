using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID
{
    public class DeleteNotamByIdCommand : IRequest<DeleteNotamByIdCommandResponse>
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string IATA { get; set; }
        public string Runway { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comments { get; set; }
        public bool? IsExpired { get; set; }
    }
}
