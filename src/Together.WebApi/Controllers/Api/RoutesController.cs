using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together.DataAccess;
using Together.Domain.Entities;
using Together.Services;
using Together.Services.Models;
using Together.Services.Requests;
using Together.WebApi.ViewModels;

namespace Together.WebApi.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TogetherDbContext _dbContext;
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RoutesController(IHttpContextAccessor httpContextAccessor, TogetherDbContext dbContext, IRouteService routeService, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _routeService = routeService;
            _mapper = mapper;
            _caller = _httpContextAccessor.HttpContext.User;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            using (_dbContext)
            {
                var route = await _dbContext.Routes
                    .Include(r=>r.Creator)
                    .Include(r=>r.RoutePoints)
                    .Include(r=>r.Passengers)
                    .FirstOrDefaultAsync(r=> r.Id == id);

                if (route != null)
                {
                    var vm = _mapper.Map<RouteModel>(route);
                    return Ok(vm);
                }
            }
            return NotFound();
        }
        
        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            using (_dbContext)
            {
                var routes = await _dbContext.Routes
                    .Include(r => r.Creator)
                    .Include(r => r.Passengers)
                    .Include(r => r.RoutePoints)
                    .ToListAsync();

                if (routes != null)
                {
                    var vm = _mapper.Map<IEnumerable<RouteModel>>(routes);
                    return Ok(vm);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteRequest createRouteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = _caller.Claims.Single(c => c.Type == "id").Value;

            var route = _mapper.Map<Route>(createRouteViewModel, o => { o.Items["userId"] = userId; });

            using (_dbContext)
            {
                //TODO: route validation
                //TODO: add user check;

                _dbContext.Routes.Add(route);

                await _dbContext.SaveChangesAsync();

                //TODO: overload method to have it accept entities : AddPassengers(User, Route)
                await _routeService.AddPassenger(new CreatePassengerRequest() { RouteId = route.Id, UserId = userId });

                var vm = _mapper.Map<RouteModel>(route);

                return Ok(vm);
            }
        }

        [HttpPut]
        [Route("{routeId}/routepoint")]
        public async Task<IActionResult> AddRoutePoint([FromRoute]int routeId, [FromBody]CreateRoutePointRequest model)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var userId = _caller.Claims.Single(c => c.Type == "id")?.Value;

            if(userId == null)
            {
                throw new Exception("Invalid user");
            }
            
            if(model.RouteId != routeId)
            {
                throw new Exception("RouteId is invalid");
            }

            if(model.UserId != userId)
            {
                throw new Exception("UserId is invalid");
            }

            using (_dbContext)
            {
                var route = await _dbContext.Routes
                    .Include(r => r.RoutePoints)
                        .ThenInclude(rp => rp.Route)
                    .Include(r => r.Creator)
                    .FirstOrDefaultAsync(r => r.Id == model.RouteId);

                if(route == null)
                {
                    throw new Exception("Route not found");
                }

                var routePoint = _mapper.Map<RoutePoint>(model, o => { o.Items["userId"] = userId; });

                if(route.RoutePoints.FirstOrDefault(rp => rp.Latitude == model.Latitude && rp.Longitude == model.Longitude) != null)
                {
                    throw new Exception("RoutePoint with the same coordinates already exists!");
                }

                route.RoutePoints.Add(routePoint);

                await _dbContext.SaveChangesAsync();
                var responseModel = _mapper.Map<RoutePointModel>(routePoint);
                return Ok(responseModel);
            }


        }

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var profile = await _dbContext.UserProfiles.Include(c => c.UserAccount).SingleAsync(c => c.UserAccount.Id == userId.Value);

            return new OkObjectResult(new
            {
                Message = "This is secure API and user data!",
                profile.FirstName,
                profile.LastName,
                profile.UserAccount.Email,
                profile.UserAccount.Id
            });
        }
    }
}