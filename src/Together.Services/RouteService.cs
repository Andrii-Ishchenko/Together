using System;
using System.Collections.Generic;
using System.Text;
using Together.DataAccess;
using Together.Domain.Entities;

namespace Together.Services
{
    public class RouteService
    {
        private readonly TogetherDbContext _dbContext;

        public RouteService(TogetherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
