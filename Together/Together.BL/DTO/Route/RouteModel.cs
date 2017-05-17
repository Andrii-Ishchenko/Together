using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.BL.DTO
{
    public class RouteModel
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int Passengers { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }

        public bool IsPrivate { get; set; }

        public UserListModel Owner { get; set; }

        public List<RoutePointListModel> Points { get; set; }

    }
}
