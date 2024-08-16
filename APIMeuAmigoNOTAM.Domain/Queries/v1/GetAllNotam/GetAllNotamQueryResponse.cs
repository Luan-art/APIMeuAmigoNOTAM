using APIMeuAmigoNOTAM.Domain.Dtos.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQueryResponse
    {
        public List<NotamDTO> Notams { get; set; }

    }
}
