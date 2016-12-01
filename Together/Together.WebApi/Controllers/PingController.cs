using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Together.WebApi.Controllers
{
    public class PingController : ApiController
    {
        [HttpGet]
        public string Ping()
        {
            return "API STATUS: OK";
        }
    }
}
