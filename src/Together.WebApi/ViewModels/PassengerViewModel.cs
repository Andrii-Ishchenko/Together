using System;

namespace Together.WebApi.ViewModels
{
    public class PassengerViewModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public string UserId { get; set; }

        public string PassengerFirstName { get; set; }

        public string PassengerLastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}