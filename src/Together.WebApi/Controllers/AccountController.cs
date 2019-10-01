using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Together.Services.Functions;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IRegister _register;

        public AccountController()
        {
            _register = new Register(new DataAccess.TogetherDbContextFactory());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Register(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NewUserModel result = await _register.RegisterUserAsync(request);
            if(result == null)
            {
                return Conflict();
            }

            return Ok(result);
        } 
    }
}