﻿using APIMeuAmigoNOTAM.Domain.Entities.v1;
using System;
using System.Collections.Generic;

namespace APIMeuAmigoNOTAM.UnitTest.Mocks.Entities
{
    public static class NotamMock
    {
        private static Random random = new Random();

        private static Notam CreateNotam(string id, string type = "DefaultType", string iata = "DefaultIATA", string runway = "DefaultRunway", DateTime? expiryDate = null, DateTime? startTime = null, DateTime? endTime = null, string comments = "DefaultComment", bool isExpired = false)
        {
            return new Notam
            {
                Id = id ?? GenerateRandomId(), 
                Type = type,
                IATA = iata,
                Runway = runway,
                ExpiryDate = expiryDate ?? DateTime.UtcNow.AddDays(10),
                StartTime = startTime ?? DateTime.UtcNow,
                EndTime = endTime ?? DateTime.UtcNow.AddHours(2),
                Comments = comments,
                IsExpired = isExpired
            };
        }

        public static string GenerateRandomId()
        {
            return $"NOTAM{random.Next(1000, 9999)}";
        }

        public static List<Notam> GetNotams()
        {
            return new List<Notam>
            {
                CreateNotam("1", "A", "JFK", "4L", DateTime.Now.AddDays(10), DateTime.Now, DateTime.Now.AddHours(2), "Routine maintenance", false),
                CreateNotam("2", "B", "LAX", "33R", DateTime.Now.AddDays(20), DateTime.Now, DateTime.Now.AddHours(3), "Nightly construction", false),
                CreateNotam("3", "C", "ORD", "7L", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), "Emergency repair", true),
                CreateNotam("4", "D", "DFW", "18F", DateTime.Now.AddDays(5), DateTime.Now, DateTime.Now.AddHours(5), "Pre-flight checks", false),
                CreateNotam("5", "E", "SEA", "16C", DateTime.Now.AddDays(15), DateTime.Now, DateTime.Now.AddHours(4), "Weather conditions", false)
            };
        }
    }
}
