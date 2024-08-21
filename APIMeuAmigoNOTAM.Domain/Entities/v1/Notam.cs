using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Dtos.v1;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace APIMeuAmigoNOTAM.Domain.Entities.v1
{
    public class Notam : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Type { get; set; }
        public string IATA { get; set; }
        public string Runway { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Comments { get; set; }
        public bool IsExpired { get; set; } 

    }
}
