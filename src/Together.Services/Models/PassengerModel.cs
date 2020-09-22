using System;

namespace Together.Services.Models
{
    public class PassengerModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}