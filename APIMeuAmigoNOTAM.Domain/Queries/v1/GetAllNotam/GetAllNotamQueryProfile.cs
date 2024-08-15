using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQueryProfile : Profile
    {
        public GetAllNotamQueryProfile()
        {
            CreateMap<Notam, GetAllNotamQueryResponse>();

        }
    }
}
