using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Together.Domain.Identity;

namespace Together.Domain
{
    public class RoutePoint
    {
        [Key]
        public int Id { get; set; }

        public DateTime SuggestDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public bool IsConfirmed { get; set; }
          
        public int? ListOrder { get; set; }

        #region Navigation 

        public int SuggestUserId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public int RouteId { get; set; }

        [ForeignKey("SuggestUserId")]
        public virtual AppUser SuggestUser { get; set; }

        [ForeignKey("RouteId")]
		public virtual Route Route { get; set; }

        #endregion

    }
}
