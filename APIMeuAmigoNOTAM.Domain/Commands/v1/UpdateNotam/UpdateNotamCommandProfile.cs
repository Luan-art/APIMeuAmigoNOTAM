using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam
{
    public class UpdateNotamCommandProfile : AutoMapper.Profile
    {
        public UpdateNotamCommandProfile()
        {
            CreateMap<UpdateNotamCommand, Notam>()
                .ForMember(fieldOutput => fieldOutput.Id, option => option
                    .MapFrom(input => input));

            CreateMap<Notam, UpdateNotamCommandResponse>();
        }

    }
}
