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
        [HttpGet("{routeId}")]
        public async Task<IActionResult> GetRoute(int routeId)
        {
            if (!ModelState.IsValid) return BadRequest();

            var route = await _routeService.GetRoute(routeId);

            if (route == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RouteModel>(route));
        }
        
        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> List()
        {

            var list = await _routeService.List();

            if(list == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RouteModel>>(list));        
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

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var profile = await _dbContext.UserProfiles
                .AsNoTracking()
                .Include(c => c.UserAccount)
                .SingleAsync(c => c.UserAccount.Id == userId.Value);

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