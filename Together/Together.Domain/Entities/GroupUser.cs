using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class GroupUser
    {
        public int Id { get; set; }

        public bool IsOwner { get; set; }
     
        public int GroupId { get; set; }

        public int UserId { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
