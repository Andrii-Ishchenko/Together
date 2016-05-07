using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Together.BL.DTOEntities;
using Together.BL.Services.Abstract;

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
        public IEnumerable<PointDto> Get()
        {
            return _pointService.GetAll<PointDto>();
        }
    }
}