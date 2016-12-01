﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.DAL.Infrastructure.Concrete;
using Together.DAL.Repository.Abstract;
using Together.Domain.Entities;

namespace Together.DAL.Repository.Concrete
{
    public class RoutePointRepository : BaseRepository<RoutePoint>, IRoutePointRepository
    {
        public RoutePointRepository(TogetherDbContext context) : base(context)
        {
        }
    }
}