using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Together.BL.Services.Abstract;
using Together.Domain.Entities;

namespace Together.Web.ApiControllers
{
    public class PointsController : ApiController
    {
        private IPointService _pointService;

        public PointsController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public IEnumerable<Point> Get()
        {
            return _pointService.GetAll();
        }
    }
}