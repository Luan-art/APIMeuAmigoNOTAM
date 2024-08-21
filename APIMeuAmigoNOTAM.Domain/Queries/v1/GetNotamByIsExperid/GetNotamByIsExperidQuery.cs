using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid
{
    public class GetNotamByIsExperidQuery : IRequest<GetNotamByIsExperidQueryResponse>
    {
        public bool isExperid { get; set; }

    }
}
