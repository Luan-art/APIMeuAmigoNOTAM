﻿using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQuery : IRequest<GetAllNotamQueryResponse>
    {
        public string Id { get; set; }

    }
}
