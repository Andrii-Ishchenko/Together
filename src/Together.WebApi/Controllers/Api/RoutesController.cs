using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together.DataAccess;

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

        public RoutesController(IHttpContextAccessor httpContextAccessor, TogetherDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _caller = _httpContextAccessor.HttpContext.User;
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