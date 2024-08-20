using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam
{
    public class UpdateNotamCommandResponse
    {
        public string Id { get; set; }

        public static explicit operator UpdateNotamCommandResponse(Notam notam)
        {
            return new UpdateNotamCommandResponse
            {
                Id = notam.Id
            };
        }
    }

}
