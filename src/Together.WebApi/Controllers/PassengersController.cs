using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Together.DataAccess;
using Together.Services;
using Together.Services.Models;
using Together.Services.Requests;

namespace Together.WebApi.Controllers
{
    public class PassengersController : ApiController
    {
        private readonly IPassengerService _passengerService;

        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpPost]
        public IHttpActionResult CreatePassenger([FromBody]CreatePassengerRequest createPassengerRequest)
        {
            NewPassengerModel passenger;
            try
            {
                passenger = _passengerService.AddUserToRoute(createPassengerRequest.UserId, createPassengerRequest.RouteId);
            }
            catch(Exception e)
            {
                //TODO: refactor to suppress internal exception data
                return InternalServerError(e);
            }
            return Ok(passenger);
        }

        [HttpDelete]
        public IHttpActionResult DeletePasssenger(int id)
        {
            try
            {
                _passengerService.DeletePassenger(id);
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