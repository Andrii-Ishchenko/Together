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
using Together.WebApi.ViewModels;

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
        public async Task<IActionResult> Post([FromBody] RegistrationViewModel model)
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