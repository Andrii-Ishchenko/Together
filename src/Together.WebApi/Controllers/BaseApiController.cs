using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Together.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        public string UserId => User.Identity.GetUserId();
        public string UserName => User.Identity.GetUserName();

    }
}