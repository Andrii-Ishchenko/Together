﻿using System;

namespace Together.Services.Models
{
    public class RoutePointModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string CreatorId { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}