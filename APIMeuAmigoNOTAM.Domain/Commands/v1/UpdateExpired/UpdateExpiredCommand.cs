using APIMeuAmigoNOTAM.Domain.Commands.v1.DeleteNotamByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateExpired
{
    public class UpdateExpiredCommand : IRequest<UpdateExpiredCommandResponse>
    {
        public string Id { get; set; }

    }
}
