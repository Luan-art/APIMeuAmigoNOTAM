using AutoMapper;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System.Collections.Generic;
using APIMeuAmigoNOTAM.Domain.Dtos.v1;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQueryProfile : Profile
    {
        public GetAllNotamQueryProfile()
        {
            CreateMap<Notam, NotamDTO>();

            CreateMap<List<Notam>, GetAllNotamQueryResponse>()
                .ForMember(dest => dest.Notams, opt => opt.MapFrom(src => src));
        }
    }
}
