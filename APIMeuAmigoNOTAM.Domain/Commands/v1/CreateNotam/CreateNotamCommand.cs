using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotam
    {
        public class CreateNotamCommand : IRequest<CreateNotamCommandResponse>
        {
            
        }
    }
}
