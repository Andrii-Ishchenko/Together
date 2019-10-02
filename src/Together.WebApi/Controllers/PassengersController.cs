using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Together.Services.Interfaces;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    public class PassengersController : BaseApiController
    {
        private readonly IPassengerService _passengerService;

        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpPost]
        public IHttpActionResult CreatePassenger([FromBody]CreatePassengerRequest createPassengerRequest)
        {
            NewPassengerModel passenger = _passengerService.AddUserToRoute(createPassengerRequest.UserId, createPassengerRequest.RouteId);
            return Ok(passenger);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeletePasssenger(int passengerId)
        {
            try
            {
               // int userId = User.Identity.Get
                _passengerService.DeletePassenger(UserId, passengerId);
            }
            catch (Exception e)
            {
                //TODO: refactor to suppress internal exception data
                return InternalServerError(e);
            }

            return Ok();
        }
      
    }
}