using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Together.DataAccess;
using Together.DataAccess.Identity;
using Together.Domain.Entities;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserAccountManager _userAccountManager;
        private readonly TogetherDbContext _context;

        public AccountsController(IMapper mapper, UserAccountManager userAccountManager, TogetherDbContext context)
        {
            _mapper = mapper;
            _userAccountManager = userAccountManager;
            _context = context;
        }

        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var user = HttpContext.User;

            if(user == null || user.Identity == null)
            {
                throw new Exception("Invalid user");
            }

            var userId = user.Claims.Single(c => c.Type == "id").Value;

            using (_context)
            {
                var profile = await _context.UserProfiles.FindAsync(userId);
                var vm = _mapper.Map<UserProfileModel>(profile);

                return Ok(vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<UserAccount>(model);
            var result = await _userAccountManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            using (_context)
            {
                await _context.UserProfiles.AddAsync(new UserProfile() 
                { 
                    Id = userIdentity.Id, 
                    FirstName = model.FirstName, 
                    LastName = model.LastName
                });

                await _context.SaveChangesAsync();
            }

            return Ok("Account Created");
        }
    }
}