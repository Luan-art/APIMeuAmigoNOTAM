using APIMeuAmigoNOTAM.Domain.Entities.v1;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById
{
    public class GetNotamByIdQueryProfile : Profile
    {
        public GetNotamByIdQueryProfile()
        {
            CreateMap<Notam, GetNotamByIdQueryResponse>();

        }
    }
}
