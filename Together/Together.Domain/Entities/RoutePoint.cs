using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public DateTime SuggestDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public bool IsConfirmed { get; set; }

        public int? Order { get; set; }

        public int SuggestUserId { get; set; }     

        public int PointId { get; set; }

        public int RouteId { get; set; }


        public virtual User SuggestUser { get; set; }

		public virtual Route Route { get; set; }

		public virtual Point Point { get; set; }

        
    }
}
