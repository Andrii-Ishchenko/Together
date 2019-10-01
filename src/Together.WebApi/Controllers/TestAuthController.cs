using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Together.WebApi.Controllers
{
    public class TestAuthController : ApiController
    {
        [Authorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(Order.CreateOrders());
        }

        [HttpGet]
        [Authorize]
        [Route("api/testauth/userInfo")]
        public IEnumerable<object> GetUserInfo()
        {

            var identity = User.Identity as ClaimsIdentity;
         
            return identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
        [HttpGet]
        [Authorize(Roles ="TestRole")]
        [Route("api/testauth/testrole")]
        public string OnlyTestRole()
        {
            return "Test Role auth OK!!!";
        }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public bool IsShipped { get; set; }

        public static List<Order> CreateOrders()
        {
            List<Order> OrderList = new List<Order>
            {
                new Order {OrderID = 10248, CustomerName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true },
                new Order {OrderID = 10249, CustomerName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
                new Order {OrderID = 10250,CustomerName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false },
                new Order {OrderID = 10251,CustomerName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
                new Order {OrderID = 10252,CustomerName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
            };

            return OrderList;
        }
    }
}