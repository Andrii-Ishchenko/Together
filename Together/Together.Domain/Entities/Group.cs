using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public string SecretKey { get; set; }

        public int OwnerId { get; set; }

        public virtual List<GroupUser> GroupUsers { get; set; }

        [ForeignKey("OwnerId")]
        public virtual AppUser Owner { get; set; }

    }
}
