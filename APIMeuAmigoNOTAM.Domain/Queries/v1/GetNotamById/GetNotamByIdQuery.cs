﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById
{
    public class GetNotamByIdQuery : IRequest<GetNotamByIdQueryResponse>
    {
        public string Id { get; set; }

    }
}
