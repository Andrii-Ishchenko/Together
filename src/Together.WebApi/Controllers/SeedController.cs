using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together.DataAccess;
using Together.Domain.Entities;

namespace Together.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly TogetherDbContext _context;
        private readonly TogetherDBInitializer _initializer;

        public SeedController(TogetherDbContext context, TogetherDBInitializer initializer)
        {
            _context = context;
            _initializer = initializer;
        }

        //TODO: DTO MODELS
        //TODO: Remove link to dataaccess from here
        [HttpGet]
        [Route("userslist")]
        public async Task<IEnumerable<object>> Get()
        {
            //await _initializer.Seed();

            using (_context)
            {
                return await _context.Users.Include(c => c.UserProfile)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Email = s.Email,
                        FirstName = s.UserProfile.FirstName,
                        LastName = s.UserProfile.LastName
                    })
                    .ToListAsync();
            }
            
        }
    }
}