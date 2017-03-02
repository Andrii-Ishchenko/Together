using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Together.Domain.Identity
{
    public class User : IdentityUser { 

        public virtual AppUser AppUser { get; set; }
    }
}
