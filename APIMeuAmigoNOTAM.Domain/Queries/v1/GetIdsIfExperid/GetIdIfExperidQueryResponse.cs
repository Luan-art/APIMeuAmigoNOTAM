using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetIdsIfExperid
{
    public class GetIdIfExperidQueryResponse
    {
        public List<string> Ids { get; set; }

        public static explicit operator GetIdIfExperidQueryResponse(List<Notam> notams)
        {
            var response = new GetIdIfExperidQueryResponse
            {
                Ids = notams.Where(notam => notam.ExpiryDate < DateTime.UtcNow).Select(notam => notam.Id).ToList()
            };

            return response;
        }
    }
}
