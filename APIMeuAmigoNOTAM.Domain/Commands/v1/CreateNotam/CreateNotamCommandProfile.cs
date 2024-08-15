using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandProfile : AutoMapper.Profile
    {
        public CreateNotamCommandProfile()
        {
            CreateMap<CreateNotamCommand, Notam>()
                .ForMember(fieldOutput => fieldOutput.Id, option => option
                    .MapFrom(input => input));

            CreateMap<Notam, CreateNotamCommandResponse>();
        }

    }
}
