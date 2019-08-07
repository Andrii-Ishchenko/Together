﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int CreatorId { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Route Route { get; set; }

        public virtual User Creator { get; set; }
    }
}