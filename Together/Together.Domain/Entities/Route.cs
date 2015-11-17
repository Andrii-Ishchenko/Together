using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public string RouteType { get; set; }
        
        public bool IsPrivate { get; set; }

        public bool IsLocked { get; set; }

        //Navigation properties

        public int InitiatorId { get; set; }

        public int GroupId { get; set; }

    }
}
