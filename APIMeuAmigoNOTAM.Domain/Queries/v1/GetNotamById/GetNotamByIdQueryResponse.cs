using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Queries.v1.GetNotamById
{
    public class GetNotamByIdQueryResponse
    {
        public string Type { get; set; }
        public string IATA { get; set; }
        public string Runway { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comments { get; set; }
        public bool? IsExpired { get; set; }
    }
}
