using APIMeuAmigoNOTAM.Domain.Dtos.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System.Collections.Generic;
using System.Linq;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetAllNotam
{
    public class GetAllNotamQueryResponse
    {
        public List<NotamDTO> Notams { get; set; } = new List<NotamDTO>();

        public static explicit operator GetAllNotamQueryResponse(List<Notam> notams)
        {
            var response = new GetAllNotamQueryResponse
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
