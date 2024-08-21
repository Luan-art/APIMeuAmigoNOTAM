using APIMeuAmigoNOTAM.Domain.Dtos.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam;
using APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamByIsExperid
{
    public class GetNotamByIsExperidQueryResponse
    {
        public List<NotamDTO> Notams { get; set; } = new List<NotamDTO>();

        public static explicit operator GetNotamByIsExperidQueryResponse(List<Notam> notams)
        {
            var response = new GetNotamByIsExperidQueryResponse
            {
                Notams = notams.Select(notam => new NotamDTO
                {
                    Type = notam.Type,
                    IATA = notam.IATA,
                    Runway = notam.Runway,
                    ExpiryDate = notam.ExpiryDate,
                    StartTime = notam.StartTime,
                    EndTime = notam.EndTime,
                    Comments = notam.Comments,
                    IsExpired = notam.IsExpired
                }).ToList()
            };

            return response;
        }
    }
}
