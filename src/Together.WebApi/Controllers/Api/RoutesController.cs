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
        private readonly IMapper _mapper;

        public RoutesController(IHttpContextAccessor httpContextAccessor, TogetherDbContext dbContext, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
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
                var route = await _dbContext.Routes.Include(r=>r.Creator).FirstOrDefaultAsync(r=> r.Id == id);

                if (route != null)
                {
                    var vm = _mapper.Map<RouteViewModel>(route);
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
                var routes = await _dbContext.Routes.Include(r => r.Creator).ToListAsync();

                if (routes != null)
                {
                    var vm = _mapper.Map<IEnumerable<RouteViewModel>>(routes);
                    return Ok(vm);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteViewModel createRouteViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = _caller.Claims.Single(c => c.Type == "id").Value;

            var route = _mapper.Map<Route>(createRouteViewModel, o => { o.Items["userId"] = userId; });

            using (_dbContext)
            {
                _dbContext.Routes.Add(route);

                await _dbContext.SaveChangesAsync();

                var vm = _mapper.Map<RouteViewModel>(route);

                return Ok(vm);
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