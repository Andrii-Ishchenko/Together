using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together.DataAccess;
using Together.Domain.Entities;
using Together.Services.Models;
using Together.Services.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Together.WebApi.Controllers.Api
{
    [Route("api/routes/{routeId:int}/routePoints")]
    [Authorize]
    public class RoutePointsController : Controller
    {
        private readonly TogetherDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoutePointsController(TogetherDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPoint([FromRoute]int routeId, [FromBody]CreateRoutePointRequest model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ValidateAddPoint(routeId, model);

            using (_dbContext)
            {
                var route = await _dbContext.Routes
                    .Include(r => r.RoutePoints)
                        .ThenInclude(rp => rp.Route)
                    .Include(r => r.Creator)
                    .FirstOrDefaultAsync(r => r.Id == model.RouteId);

                if (route == null)
                {
                    throw new Exception("Route not found");
                }

                var routePoint = _mapper.Map<RoutePoint>(model);

                if (route.RoutePoints.FirstOrDefault(rp => rp.Latitude == model.Latitude && rp.Longitude == model.Longitude) != null)
                {
                    throw new Exception("RoutePoint with the same coordinates already exists!");
                }

                route.RoutePoints.Add(routePoint);

                await _dbContext.SaveChangesAsync();
                var responseModel = _mapper.Map<RoutePointModel>(routePoint);
                return Ok(responseModel);
            }


        }

        public void ValidateAddPoint(int routeId, [FromBody]CreateRoutePointRequest model)
        {
            var userId = (User.Identity as ClaimsIdentity).Claims.Single(c => c.Type == "id")?.Value;

            if (userId == null)
            {
                throw new Exception("Invalid user");
            }

            if (model.RouteId != routeId)
            {
                throw new Exception("RouteId is invalid");
            }

            if (model.UserId != userId)
            {
                throw new Exception("UserId is invalid");
            }
        }
    }
}
