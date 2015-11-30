using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public string SecretKey { get; set; }

        public virtual List<GroupUser> GroupUsers { get; set; }

        public virtual List<Route> Routes { get; set; }
    }
}
