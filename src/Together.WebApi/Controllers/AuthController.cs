using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Together.DataAccess.Identity;
using Together.WebApi.Auth;
using Together.WebApi.Helpers;
using Together.WebApi.Models;
using Together.WebApi.ViewModels;

namespace Together.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserAccountManager _userAccountManager;    
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtIssuerOptions;

        public AuthController(UserAccountManager userAccountManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtIssuerOptions)
        {
            _userAccountManager = userAccountManager;
            _jwtFactory = jwtFactory;
            _jwtIssuerOptions = jwtIssuerOptions?.Value ?? throw new ArgumentNullException(nameof(jwtIssuerOptions));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.Username, credentials.Password);
            if(identity == null)
            {
                return BadRequest("Invalid Username or Password");
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.Username, _jwtIssuerOptions) ;
            return Ok(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            var user = await _userAccountManager.FindByNameAsync(username);
            if(user == null)
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            if(await _userAccountManager.CheckPasswordAsync(user, password))
            {
                return await Task.FromResult<ClaimsIdentity>(_jwtFactory.GenerateClaimsIdentity(username, user.Id));
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}