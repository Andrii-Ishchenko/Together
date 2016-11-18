using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreateDate { get; set; }

        public int MaxPassengers { get; set; }

        public string RouteType { get; set; }
        
        public bool IsPrivate { get; set; }

        public string SecretKey { get; set; }

        #region Navigation

        public int OwnerId { get; set; }

        public virtual List<RoutePoint> RoutePoints { get; set; }

		public virtual List<RouteUser> RouteUsers { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        #endregion
    }
}
